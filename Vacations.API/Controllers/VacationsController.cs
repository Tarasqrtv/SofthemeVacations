using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vacations.BLL.Models;
using Vacations.BLL.Services;

namespace Vacations.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationsController : ControllerBase
    {
        private readonly IVacationsService _vacationsService;

        public VacationsController(
            IVacationsService vacationsService
            )
        {
            _vacationsService = vacationsService;
        }

        [Authorize(Roles = "Admin, TeamLead")]
        [HttpGet]
        public async Task<IEnumerable<VacationDto>> GetVacation()
        {
            return await _vacationsService.GetVacationRequestsAsync(User);
        }

        [Authorize(Roles = "Admin, TeamLead")]
        [HttpGet("{id}")]
        public async Task<VacationDto> GetVacationById([FromRoute] Guid id)
        {
            return await _vacationsService.GetByIdAsync(id);
        }

        [Authorize]
        [HttpGet("employee")]
        public async Task<IEnumerable<VacationDto>> GetVacationByCurrentEmployeeAsync()
        {
            return await _vacationsService.GetByCurrentEmployeeIdAsync(User);
        }

        [Authorize]
        [HttpGet("employee/{id}")]
        public IEnumerable<VacationDto> GetVacationByEmployeeId([FromRoute] Guid id)
        {
            var vacations = _vacationsService.GetByEmployeeId(id);

            return vacations;
        }

        [Authorize]
        [HttpPost("employee")]
        public async Task<IActionResult> PostVacarion([FromBody] VacationDto vacationsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _vacationsService.PostCurrentAsync(User, vacationsDto);
            }
            catch (DbUpdateException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [Authorize(Roles = "Admin, TeamLead")]
        [HttpPost("employee/{id}")]
        public async Task<IActionResult> PostVacarion([FromRoute] Guid id, [FromBody] VacationDto vacationsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _vacationsService.PostAsync(vacationsDto);
            }
            catch (DbUpdateException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }
    }
}