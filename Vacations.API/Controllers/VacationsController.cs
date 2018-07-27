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
    public class VacationsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUsersService _usersService;
        private readonly IVacationsService _vacationsService;

        public VacationsController(IMapper mapper, IUsersService usersService, IVacationsService vacationsService)
        {
            _mapper = mapper;
            _usersService = usersService;
            _vacationsService = vacationsService;
        }

        // GET: api/Vacations
        [HttpGet]
        public IEnumerable<VacationDto> GetVacation()
        {
            var vacations = _vacationsService.Get();

            return _mapper.Map<IEnumerable<VacationDto>,IEnumerable <VacationDto>>(vacations);
        }

        [HttpGet("employee")]
        public IEnumerable<VacationDto> GetVacationByCurrentEmployee()
        {
            var currentUserEmail = User.FindFirst(ClaimTypes.Email)?.Value;

            var userDto =_usersService.GetByEmail(currentUserEmail);

            var userModel = _mapper.Map<UserDto, UserModel>(userDto);

            var vacations = _vacationsService.GetByEmployeeId(userModel.EmployeeId);

            return _mapper.Map<IEnumerable<VacationDto>, IEnumerable<VacationDto>>(vacations);
        }

        [HttpGet("employee/{id}")]
        public IEnumerable<VacationDto> GetVacationByEmployeeId([FromRoute] Guid id)
        {
            var vacations = _vacationsService.GetByEmployeeId(id);

            return _mapper.Map<IEnumerable<VacationDto>, IEnumerable<VacationDto>>(vacations);
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