using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vacations.BLL.Services;

namespace Vacations.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        private readonly IUsersService _usersService;

        public ProfileController(
            IProfileService profileService,
            IUsersService usersService
            )
        {
            _profileService = profileService;
            _usersService = usersService;
        }

        [Authorize]
        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentProfile()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentUser = await _usersService.GetUserAsync(User);

            var profileDto = await _profileService.GetByIdAsync(currentUser.EmployeeId);

            return Ok(profileDto);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfile([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var profileDto = await _profileService.GetByIdAsync(id);

            return Ok(profileDto);
        }
    }
}