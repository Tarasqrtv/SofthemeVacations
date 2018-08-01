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
    public class EmployeeStatusController : ControllerBase
    {
        private readonly IEmployeeStatusService _employeeStatusService;

        public EmployeeStatusController(IEmployeeStatusService employeeStatusService)
        {
            _employeeStatusService = employeeStatusService;
        }

        [Authorize]
        [HttpGet]
        public IEnumerable<EmployeeStatusDto> GetEmployeeStatus()
        {
            return _employeeStatusService.Get();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeStatus([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeStatus = await _employeeStatusService.GetByIdAsync(id);

            if (employeeStatus == null)
            {
                return NotFound();
            }

            return Ok(employeeStatus);
        }
    }
}