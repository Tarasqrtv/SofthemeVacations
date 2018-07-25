using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vacations.DAL.Models;

namespace Vacations.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeStatusController : ControllerBase
    {
        private readonly VacationsDbContext _context;

        public EmployeeStatusController(VacationsDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeStatus
        [HttpGet]
        public IEnumerable<EmployeeStatus> GetEmployeeStatus()
        {
            return _context.EmployeeStatus;
        }

        // GET: api/EmployeeStatus/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeStatus([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeStatus = await _context.EmployeeStatus.FindAsync(id);

            if (employeeStatus == null)
            {
                return NotFound();
            }

            return Ok(employeeStatus);
        }

        // PUT: api/EmployeeStatus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeStatus([FromRoute] Guid id, [FromBody] EmployeeStatus employeeStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeStatus.EmployeeStatusId)
            {
                return BadRequest();
            }

            _context.Entry(employeeStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeStatusExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EmployeeStatus
        [HttpPost]
        public async Task<IActionResult> PostEmployeeStatus([FromBody] EmployeeStatus employeeStatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EmployeeStatus.Add(employeeStatus);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeStatusExists(employeeStatus.EmployeeStatusId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployeeStatus", new { id = employeeStatus.EmployeeStatusId }, employeeStatus);
        }

        // DELETE: api/EmployeeStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeStatus([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeStatus = await _context.EmployeeStatus.FindAsync(id);
            if (employeeStatus == null)
            {
                return NotFound();
            }

            _context.EmployeeStatus.Remove(employeeStatus);
            await _context.SaveChangesAsync();

            return Ok(employeeStatus);
        }

        private bool EmployeeStatusExists(Guid id)
        {
            return _context.EmployeeStatus.Any(e => e.EmployeeStatusId == id);
        }
    }
}