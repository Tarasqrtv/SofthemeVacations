using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vacations.API.Models;
using Vacations.BLL.Services;

namespace Vacations.API.Controllers
{
    [Produces("application/json")]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IUsersService _usersService;

        public AuthController(
            IUsersService usersService
        )
        {
            _usersService = usersService;
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
            await _usersService.ResetPasswordAsync(passwordReset.EmployeeId, passwordReset.Code, passwordReset.Password);
            return Ok();
        }
    }
}