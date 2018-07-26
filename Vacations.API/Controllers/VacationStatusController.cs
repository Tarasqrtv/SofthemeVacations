using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vacations.BLL.Models;
using Vacations.BLL.Services;
using Vacations.DAL.Models;

namespace Vacations.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationStatusController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUsersService _usersService;
        private readonly IVacationStatusService _vacationStatusService;

        public VacationStatusController(IMapper mapper, IUsersService usersService, IVacationStatusService vacationStatusService)
        {
            _mapper = mapper;
            _usersService = usersService;
            _vacationStatusService = vacationStatusService;
        }

        // GET: api/VacationStatus
        [HttpGet]
        public IEnumerable<VacationStatusDto> GetVacationStatus()
        {
            return _vacationStatusService.Get();
        }

        // GET: api/VacationStatus/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVacationStatus([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vacationStatus = await _vacationStatusService.GetByIdAsync(id);

            if (vacationStatus == null)
            {
                return NotFound();
            }

            return Ok(vacationStatus);
        }

    //    // PUT: api/VacationStatus/5
    //    [HttpPut("{id}")]
    //    public async Task<IActionResult> PutVacationStatus([FromRoute] Guid id, [FromBody] VacationStatus vacationStatus)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        if (id != vacationStatus.VacationStatusId)
    //        {
    //            return BadRequest();
    //        }

    //        _context.Entry(vacationStatus).State = EntityState.Modified;

    //        try
    //        {
    //            await _context.SaveChangesAsync();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!VacationStatusExists(id))
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

    //    // POST: api/VacationStatus
    //    [HttpPost]
    //    public async Task<IActionResult> PostVacationStatus([FromBody] VacationStatus vacationStatus)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        _context.VacationStatus.Add(vacationStatus);
    //        try
    //        {
    //            await _context.SaveChangesAsync();
    //        }
    //        catch (DbUpdateException)
    //        {
    //            if (VacationStatusExists(vacationStatus.VacationStatusId))
    //            {
    //                return new StatusCodeResult(StatusCodes.Status409Conflict);
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return CreatedAtAction("GetVacationStatus", new { id = vacationStatus.VacationStatusId }, vacationStatus);
    //    }

    //    // DELETE: api/VacationStatus/5
    //    [HttpDelete("{id}")]
    //    public async Task<IActionResult> DeleteVacationStatus([FromRoute] Guid id)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }

    //        var vacationStatus = await _context.VacationStatus.FindAsync(id);
    //        if (vacationStatus == null)
    //        {
    //            return NotFound();
    //        }

    //        _context.VacationStatus.Remove(vacationStatus);
    //        await _context.SaveChangesAsync();

    //        return Ok(vacationStatus);
    //    }

    //    private bool VacationStatusExists(Guid id)
    //    {
    //        return _context.VacationStatus.Any(e => e.VacationStatusId == id);
    //    }
    }
}