using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vacations.BLL.Models;
using Vacations.BLL.Services;
namespace Vacations.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public RolesController(
             IUsersService usersService
             )
        {
            _usersService = usersService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IEnumerable<RoleDto> Get()
        {
            return _usersService.GetRoles();
        }
    }
}