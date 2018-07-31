using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Vacations.API.Models;
using Vacations.BLL.Services;
using Vacations.DAL.Models;

namespace Vacations.API.Controllers
{
    [Produces("application/json")]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IUsersService _usersService;

        public AuthController(
            UserManager<User> userManager,
            IConfiguration configuration,
            IUsersService usersService
        )
        {
            _usersService = usersService;
            _userManager = userManager;
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

        [HttpPost]
        [AllowAnonymous]
        [Route("Forgot-Password")]
        public async Task<IActionResult> ForgotPassword([FromBody] Mail email)
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
        [Route("Reset-Password")]
        public async Task<IActionResult> SendPasswordEmailResetRequestAsync([FromBody] PasswordReset passwordReset)
        {
            var userEntity = await _userManager.FindByIdAsync(passwordReset.EmployeeId);
            var codeDecodedBytes = WebEncoders.Base64UrlDecode(passwordReset.Code);
            var codeDecoded = Encoding.UTF8.GetString(codeDecodedBytes);
            await _userManager.ResetPasswordAsync(userEntity, codeDecoded, passwordReset.Password);
            return Ok();
        }
    }
}