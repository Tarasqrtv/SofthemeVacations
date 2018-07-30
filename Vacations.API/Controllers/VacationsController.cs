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
    public class VacationsController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IVacationsService _vacationsService;

        public VacationsController(
            UserManager<User> userManager,
            IVacationsService vacationsService
            )
        {
            _userManager = userManager;
            _vacationsService = vacationsService;
        }

        // GET: api/Vacations
        [HttpGet]
        public IEnumerable<VacationDto> GetVacation()
        {
            var vacations = _vacationsService.Get();

            return vacations;
        }

        [HttpGet("employee")]
        public IEnumerable<VacationDto> GetVacationByCurrentEmployee()
        {
            var currentUserEmail = User.FindFirst(ClaimTypes.Email)?.Value;

            var currentUser = _userManager.GetUserAsync(User);

            var userDto = currentUser.Result;

            var vacations = _vacationsService.GetByEmployeeId(userDto.EmployeeId);

            return vacations;
        }

        [HttpGet("employee/{id}")]
        public IEnumerable<VacationDto> GetVacationByEmployeeId([FromRoute] Guid id)
        {
            var vacations = _vacationsService.GetByEmployeeId(id);

            return vacations;
        }

        // POST: api/Employees
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostEmployee([FromBody] VacationDto vacationsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentUserEmail = User.FindFirst(ClaimTypes.Email)?.Value;

            var currentUser = _userManager.GetUserAsync(User);

            var userDto = currentUser.Result;

            vacationsDto.EmployeeId = userDto.EmployeeId;

            try
            {
                await _vacationsService.PostAsync(vacationsDto);
            }
            catch (DbUpdateException e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }
    }
}