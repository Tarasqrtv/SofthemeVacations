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
    public class JobTitlesController : ControllerBase
    {
        private readonly VacationsDbContext _context;

        public JobTitlesController(VacationsDbContext context)
        {
            _context = context;
        }

        // GET: api/JobTitles
        [HttpGet]
        public IEnumerable<JobTitle> GetJobTitle()
        {
            return _context.JobTitle;
        }

        // GET: api/JobTitles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobTitle([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobTitle = await _context.JobTitle.FindAsync(id);

            if (jobTitle == null)
            {
                return NotFound();
            }

            return Ok(jobTitle);
        }

        // PUT: api/JobTitles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobTitle([FromRoute] Guid id, [FromBody] JobTitle jobTitle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jobTitle.JobTitleId)
            {
                return BadRequest();
            }

            _context.Entry(jobTitle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobTitleExists(id))
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

        // POST: api/JobTitles
        [HttpPost]
        public async Task<IActionResult> PostJobTitle([FromBody] JobTitle jobTitle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.JobTitle.Add(jobTitle);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JobTitleExists(jobTitle.JobTitleId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetJobTitle", new { id = jobTitle.JobTitleId }, jobTitle);
        }

        // DELETE: api/JobTitles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobTitle([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobTitle = await _context.JobTitle.FindAsync(id);
            if (jobTitle == null)
            {
                return NotFound();
            }

            _context.JobTitle.Remove(jobTitle);
            await _context.SaveChangesAsync();

            return Ok(jobTitle);
        }

        private bool JobTitleExists(Guid id)
        {
            return _context.JobTitle.Any(e => e.JobTitleId == id);
        }
    }
}