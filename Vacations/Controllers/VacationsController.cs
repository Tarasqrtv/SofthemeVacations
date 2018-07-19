using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vacations.Model.Models;

namespace Vacations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationsController : ControllerBase
    {
        private readonly VacationsDBContext _context;

        public VacationsController(VacationsDBContext context)
        {
            _context = context;
        }

        // GET: api/Vacations
        [HttpGet]
        public IEnumerable<Vacation> GetVacation()
        {
            return _context.Vacation;
        }

        // GET: api/Vacations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVacation([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vacation = await _context.Vacation.FindAsync(id);

            if (vacation == null)
            {
                return NotFound();
            }

            return Ok(vacation);
        }

        // PUT: api/Vacations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVacation([FromRoute] Guid id, [FromBody] Vacation vacation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vacation.VacationId)
            {
                return BadRequest();
            }

            _context.Entry(vacation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacationExists(id))
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

        // POST: api/Vacations
        [HttpPost]
        public async Task<IActionResult> PostVacation([FromBody] Vacation vacation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Vacation.Add(vacation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VacationExists(vacation.VacationId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVacation", new { id = vacation.VacationId }, vacation);
        }

        // DELETE: api/Vacations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVacation([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vacation = await _context.Vacation.FindAsync(id);
            if (vacation == null)
            {
                return NotFound();
            }

            _context.Vacation.Remove(vacation);
            await _context.SaveChangesAsync();

            return Ok(vacation);
        }

        private bool VacationExists(Guid id)
        {
            return _context.Vacation.Any(e => e.VacationId == id);
        }
    }
}