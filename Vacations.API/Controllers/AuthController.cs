using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Vacations.API.Models;
using Vacations.BLL.Models;
using Vacations.BLL.Services;
using Vacations.DAL.Models;

namespace Vacations.API.Controllers
{
    public class RoleAndToken
    {
        public string Token { get; }
        public string Role { get; }

        public RoleAndToken(string token, string role)
        {
            Token = token;
            Role = role;
        }
    }

    [Produces("application/json")]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IMapper _mapper;

        private readonly VacationsDbContext _db;

        private readonly IConfiguration _configuration;

        private readonly IUsersService _usersService;

        public AuthController(IConfiguration configuration, IMapper mapper, IUsersService usersService)
        {
            _configuration = configuration;
            _db = new VacationsDbContext(_configuration.GetConnectionString("VacationsDBConn"));
            _mapper = mapper;
            _usersService = usersService;
        }

        [AllowAnonymous]
        [HttpGet("token")]
        public async Task<IActionResult> GetTokenAsync()
        {
            var header = Request.Headers["Authorization"];

            if (header.ToString().StartsWith("Basic"))
            {
                var credValue = header.ToString().Substring("Basic ".Length).Trim();
                var usernameAndPassenc = Encoding.UTF8.GetString(Convert.FromBase64String(credValue));
                var userEmailAndPass = usernameAndPassenc.Split(":");
                var b = new UserModel();
                var a = _mapper.Map<UserModel,UserDto>(b);
                var user = await _db.User.Include(x => x.Role).FirstOrDefaultAsync(x => x.PersonalEmail == userEmailAndPass[0]);

                if (user != null)
                {
                    if (userEmailAndPass[1] == user.Password)
                    {
                        var claimsdata = new[] { new Claim(ClaimTypes.Email, user.PersonalEmail), new Claim(ClaimTypes.Role, user.Role.Name) };

                        var token = new JwtSecurityToken
                        (
                            issuer: _configuration["Token:Issuer"],
                            audience: _configuration["Token:Audience"],
                            claims: claimsdata,
                            expires: DateTime.UtcNow.AddDays(60),
                            notBefore: DateTime.UtcNow,
                            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"])),
                                    SecurityAlgorithms.HmacSha256)
                        );

                        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                        return Ok(new RoleAndToken(tokenString, user.Role.Name));
                    }
                }

                return Unauthorized();
            }

            return BadRequest();
        }

        //[HttpPost("sendnewpass")]
        //public async Task<IActionResult> SendNewPass([FromBody] string userEmail)
        //{
        //    var user = await _db.User.FirstOrDefaultAsync(x => x.PersonalEmail == userEmail);

        //    if (user != null)
        //    {
        //        return Ok();
        //    }

        //    return BadRequest();
        //}


        //[HttpPost("setnewpass")]
        //public async Task<IActionResult> SetNewPass([FromBody] string userEmail)
        //{
        //    var user = await _db.User.FirstOrDefaultAsync(x => x.PersonalEmail == userEmail);

        //    if (user != null)
        //    {
        //        return Ok();
        //    }

        //    return BadRequest();
        //}

        [HttpGet("test1")]
        public string GetTest1()
        {
            return "non authorized";
        }

        [Authorize]
        [HttpGet("test2")]
        public string GetTest2()
        {
            return "authorized";
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("test3")]
        public string GetTest3()
        {
            return "authorized with role admin";
        }
    }
}