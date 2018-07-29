using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class ProfileController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IProfileService _profileService;

        public ProfileController(
            IMapper mapper,
            UserManager<User> userManager, 
            IProfileService profileService
            )
        {
            _mapper = mapper;
            _userManager = userManager;
            _profileService = profileService;
        }

        [Authorize]
        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentProfile()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentUser = _userManager.GetUserAsync(User);

            var userDto = currentUser.Result;

            var profileDto = await _profileService.GetByIdAsync(userDto.EmployeeId);

            return Ok(profileDto);
        }
        //---------------------------------

        //    // GET: api/Employees
        //    [Authorize(Roles = "Admin")]
        //[HttpGet("all")]
        //public IEnumerable<Employee> GetEmployee()
        //{
        //    return _context.Employee;
        //}

        //// GET: api/Employees/5
        //[Authorize(Roles = "Admin")]
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var employee = await _context.Employee.Include(i => i.JobTitle).Include(i => i.EmployeeStatus)
        //                            .FirstOrDefaultAsync(i => i.EmployeeId == id);

        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(employee);
        //}

        //// PUT: api/Employees/5
        //[Authorize(Roles = "Admin")]
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutEmployee([FromRoute] Guid id, [FromBody] Employee employee)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != employee.EmployeeId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(employee).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EmployeeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        ////TODO: Сделать без id
        //// POST: api/Employees
        //[Authorize(Roles = "Admin")]
        //[HttpPost("{id}")]
        //public async Task<IActionResult> PostEmployee([FromBody] Employee employee)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Employee.Add(employee);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (EmployeeExists(employee.EmployeeId))
        //        {
        //            return new StatusCodeResult(StatusCodes.Status409Conflict);
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        //}

        //// DELETE: api/Employees/5
        //[Authorize(Roles = "Admin")]
        //[HttpDelete("employee/{id}")]
        //public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var employee = await _context.Employee.FindAsync(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Employee.Remove(employee);
        //    await _context.SaveChangesAsync();

        //    return Ok(employee);
        //}

        //private bool EmployeeExists(Guid id)
        //{
        //    return _context.Employee.Any(e => e.EmployeeId == id);
        //}
    }
}