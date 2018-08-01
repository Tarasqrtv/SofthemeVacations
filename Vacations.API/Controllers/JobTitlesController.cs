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
    public class JobTitlesController : ControllerBase
    {
        private readonly IJobTitlesService _jobTitlesService;

        public JobTitlesController(IJobTitlesService jobTitlesService)
        {
            _jobTitlesService = jobTitlesService;
        }

        [Authorize]
        [HttpGet]
        public IEnumerable<JobTitleDto> GetJobTitle()
        {
            return _jobTitlesService.Get();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobTitle([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jobTitle = await _jobTitlesService.GetByIdAsync(id);

            if (jobTitle == null)
            {
                return NotFound();
            }

            return Ok(jobTitle);
        }
    }
}