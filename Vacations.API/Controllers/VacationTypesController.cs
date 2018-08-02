using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vacations.BLL.Models;
using Vacations.BLL.Services;

namespace Vacations.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationTypesController : ControllerBase
    {
        private readonly IVacationTypesService _vacationTypesService;

        public VacationTypesController(
            IVacationTypesService vacationTypesService
        )
        {
            _vacationTypesService = vacationTypesService;
        }

        [Authorize]
        [HttpGet]
        public IEnumerable<VacationTypesDto> GetVacationTypes()
        {
            return _vacationTypesService.Get();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GeVacationType([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vacationType = await _vacationTypesService.GetByIdAsync(id);

            if (vacationType == null)
            {
                return NotFound();
            }

            return Ok(vacationType);
        }
    }
}