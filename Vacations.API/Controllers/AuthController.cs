using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Vacations.BLL.Services;
using Vacations.DAL.Models;

namespace Vacations.API.Controllers
{
    [Produces("application/json")]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUsersService _usersService;
        //private IEmailSender _emailSender;

        public AuthController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IConfiguration configuration,
            AccountsDbContext context,
            RoleManager<IdentityRole> roleManager,
            //IEmailSender emailSender
            IUsersService usersService
        )
        {
            _usersService = usersService;
            //_emailSender = emailSender;
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpGet("token")]
        public async Task<IActionResult> GetTokenAsync()
        {
            try
            {
                var header = Request.Headers["Authorization"];

                return Ok(await _usersService.GetTokenAsync(header.ToString()));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("register")]
        public async Task<IActionResult> RegisterAsync()
        {
            var header = Request.Headers["Authorization"];

            await AddRole("Admin");
            await AddRole("TeamLead");
            await AddRole("User");

            if (header.ToString().StartsWith("Basic"))
            {
                var credValue = header.ToString().Substring("Basic ".Length).Trim();
                var usernameAndPassenc = Encoding.UTF8.GetString(Convert.FromBase64String(credValue));
                var userEmailAndPass = usernameAndPassenc.Split(":");
                var model = new RegisterDto() { Email = userEmailAndPass[0], Password = userEmailAndPass[1] };
                var user = new User
                {
                    UserName = model.Email,
                    Email = model.Email,
                    EmployeeId = Guid.Parse("95faa157-6b31-44d9-8f86-150c0dff0236")
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                var result1 = await _userManager.AddToRoleAsync(user, "Admin");

                //if (result.Succeeded)
                //{
                await _signInManager.SignInAsync(user, false);
                return Ok(_usersService.GetTokenAsync(header.ToString()));
                //}
            }
            throw new ApplicationException("UNKNOWN_ERROR");
        }

        public class ForgotPasswordViewModel
        {
            public string Email { get; set; }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordViewModel email)
        {
            if (ModelState.IsValid)
            {
                await _usersService.ForgotPassword(email.Email);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        [AllowAnonymous]
        [Route("ResetPassword")]
        public async Task<IActionResult> SendPasswordEmailResetRequestAsync([FromBody] PasswordReset passwordReset)
        {
            var userEntity = await _userManager.FindByIdAsync(passwordReset.Id);
            var codeDecodedBytes = WebEncoders.Base64UrlDecode(passwordReset.Code);
            var codeDecoded = Encoding.UTF8.GetString(codeDecodedBytes);
            await _userManager.ResetPasswordAsync(userEntity, codeDecoded, passwordReset.Password);
            return Ok();
        }

        public async Task<IActionResult> AddRole(string role)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
            return Json(_roleManager.Roles);
        }

        public class LoginDto
        {
            [Required]
            public string Email { get; set; }

            [Required]
            public string Password { get; set; }

        }

        public class RegisterDto
        {
            [Required]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "PASSWORD_MIN_LENGTH", MinimumLength = 6)]
            public string Password { get; set; }
        }
    }

    public class PasswordReset
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public string Code { get; set; }
    }
}