using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Vacations.Controllers
{
    public class Userr
    {
        public string Name { get; }
        public string Pass { get; }
        public string Role { get; }

        public Userr(string name, string pass, string role)
        {
            Name = name;
            Pass = pass;
            Role = role;
        }
    }

    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        Userr[] _users = new Userr[]
        {
            new Userr("Alex", "pass", "admin"),
            new Userr("Taras", "pass", "teamlead"),
            new Userr("Luda", "pass", "user"),
        };

        [HttpPost("token")]
        public IActionResult Token()
        {
            //string tokenString = "test";
            var header = Request.Headers["Authorization"];
            if (header.ToString().StartsWith("Basic"))
            {
                var credValue = header.ToString().Substring("Basic ".Length).Trim();
                var usernameAndPassenc = Encoding.UTF8.GetString(Convert.FromBase64String(credValue)); //admin:pass
                var usernameAndPass = usernameAndPassenc.Split(":");
                //check in DB username and pass exist
                foreach (var user in _users)
                {
                    if (usernameAndPass[0] == user.Name && usernameAndPass[1] == user.Pass)
                    {
                        var claimsdata = new[] { new Claim(ClaimTypes.Name, usernameAndPass[0]), new Claim(ClaimTypes.Role, user.Role), };
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ahbasshfbsahjfbshajbfhjasbfashjbfsajhfvashjfashfbsahfbsahfksdjf"));
                        var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
                        var token = new JwtSecurityToken(

                            issuer: "mysite.com",
                            audience: "mysite.com",
                            expires: DateTime.Now.AddMinutes(1),
                            claims: claimsdata,
                            signingCredentials: signInCred
                        );
                        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                        return Ok(tokenString);
                    }
                }
            }
            return BadRequest("wrong request");

            // return View();
        }

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

        [Authorize(Roles = "admin")]
        [HttpGet("test3")]
        public string GetTest3()
        {
            return "authorized with role admin";
        }
    }
}