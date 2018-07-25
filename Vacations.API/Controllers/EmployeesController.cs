using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vacations.API.Models;
using Vacations.BLL.Models;
using Vacations.BLL.Services;
using Vacations.DAL.Models;

namespace Vacations.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUsersService _usersService;
        private readonly IEmployeesService _employeesService;

        public EmployeesController(IMapper mapper, IUsersService usersService, IEmployeesService employeesService)
        {
            _mapper = mapper;
            _usersService = usersService;
            _employeesService = employeesService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCurrentEmployee()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentUserEmail = User.FindFirst(ClaimTypes.Email)?.Value;

            var userDto = await _usersService.GetByEmailAsync(currentUserEmail);
            var userModel = _mapper.Map<UserDto, UserModel>(userDto);

            var employeeDto = await _employeesService.GetByIdAsync(userModel.EmployeeId);
            var employeeModel = _mapper.Map<EmployeeDto, EmployeeModel>(employeeDto);

            return Ok(employeeModel);
        }

        //    // GET: api/Employees
        //    [Authorize(Roles = "Admin")]
        //    [HttpGet("all")]
        //    public IEnumerable<Employee> GetEmployee()
        //    {
        //        return _context.Employee;
        //    }

        //    // GET: api/Employees/5
        //    [Authorize(Roles = "Admin")]
        //    [HttpGet("{id}")]
        //    public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        var employee = await _context.Employee.Include(i => i.JobTitle).Include(i => i.EmployeeStatus)
        //                                .FirstOrDefaultAsync(i => i.EmployeeId == id);

        //        if (employee == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(employee);
        //    }

        //    // PUT: api/Employees/5
        //    [Authorize(Roles = "Admin")]
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutEmployee([FromRoute] Guid id, [FromBody] Employee employee)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        if (id != employee.EmployeeId)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(employee).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!EmployeeExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }

        //    //TODO: Сделать без id
        //    // POST: api/Employees
        //    [Authorize(Roles = "Admin")]
        //    [HttpPost("{id}")]
        //    public async Task<IActionResult> PostEmployee([FromBody] Employee employee)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        _context.Employee.Add(employee);
        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateException)
        //        {
        //            if (EmployeeExists(employee.EmployeeId))
        //            {
        //                return new StatusCodeResult(StatusCodes.Status409Conflict);
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        //    }

        //    // DELETE: api/Employees/5
        //    [Authorize(Roles = "Admin")]
        //    [HttpDelete("employee/{id}")]
        //    public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        var employee = await _context.Employee.FindAsync(id);
        //        if (employee == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Employee.Remove(employee);
        //        await _context.SaveChangesAsync();

        //        return Ok(employee);
        //    }

        //    private bool EmployeeExists(Guid id)z
        //    {
        //        return _context.Employee.Any(e => e.EmployeeId == id);
        //    }
    }
}