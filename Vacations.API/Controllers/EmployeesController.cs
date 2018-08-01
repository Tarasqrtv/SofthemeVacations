using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vacations.BLL.Models;
using Vacations.BLL.Services;
using Vacations.DAL.Models;

namespace Vacations.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IEmployeesService _employeesService;

        public EmployeesController(
            IMapper mapper,
            UserManager<User> userManager,
            IEmployeesService employeesService)
        {
            _userManager = userManager;
            _employeesService = employeesService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IEnumerable<EmployeeDtoList> Get()
        {
            return _employeesService.Get();
        }

        [Authorize]
        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentEmployee()
        {
            var userDto = await _userManager.GetUserAsync(User);

            if (userDto == null)
            {
                return BadRequest("User == null");
            }

            var employeeDto = await _employeesService.GetByIdAsync(userDto.EmployeeId);

            return Ok(employeeDto);
        }

        [Authorize]
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
            var employeeDto = await _employeesService.GetByIdAsync(id);

            if (employeeDto == null)
            {
                return NotFound("Employee not found");
            }

            return Ok(employeeDto);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> PutEmployee([FromBody] EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _employeesService.PutAsync(employeeDto);

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> PostEmployee([FromBody] EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _employeesService.PostAsync(employeeDto);
            }
            catch (DbUpdateException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }
    }
}