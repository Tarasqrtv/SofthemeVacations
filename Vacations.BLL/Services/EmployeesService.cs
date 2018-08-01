using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using Vacations.BLL.Models;
using Vacations.DAL.Models;

namespace Vacations.BLL.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IMapper _mapper;
        private readonly VacationsDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUsersService _usersService;

        public EmployeesService(
            VacationsDbContext context,
            IMapper mapper,
            UserManager<User> userManager,
            IUsersService usersService,
            RoleManager<IdentityRole> roleManager
            )
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
            _usersService = usersService;
            _roleManager = roleManager;
        }

        public IEnumerable<EmployeeDtoList> Get()
        {
            var employees = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDtoList>>(_context.Employee);
            return employees;
        }

        public async Task<EmployeeDto> GetByIdAsync(Guid id)
        {
            var employee = await _context.Employee
                .Include(e => e.Team.TeamLead)
                .Include(e => e.User)
                .FirstOrDefaultAsync(e => e.EmployeeId == id);

            if (employee != null)
                return new EmployeeDto()
                {
                    EmployeeId = employee.EmployeeId,
                    Name = employee.Name,
                    Surname = employee.Surname,
                    Birthday = employee.Birthday,
                    PersonalEmail = employee.PersonalEmail,
                    WorkEmail = employee.WorkEmail,
                    TelephoneNumber = employee.TelephoneNumber,
                    Skype = employee.Skype,
                    StartDate = employee.StartDate,
                    EndDate = employee.EndDate,
                    TeamName = employee.Team?.Name,
                    TeamLeadName = employee.Team?.TeamLead.Name,
                    TeamLeadSurname = employee.Team?.TeamLead.Surname,
                    Balance = employee.Balance,
                    EmployeeStatusId = employee.EmployeeStatusId,
                    JobTitleId = employee.JobTitleId,
                    TeamId = employee.TeamId,
                    TeamLeadId = employee.Team?.TeamLead.EmployeeId,
                    RoleId = (await _userManager.GetRolesAsync(employee.User)).FirstOrDefault()
                };
            throw new NullReferenceException("Employee not found!");
        }

        public async Task<int> PutAsync(EmployeeDto employeeDto)
        {
            var employee = await _context.Employee.FindAsync(employeeDto.EmployeeId);

            var user = await _userManager.FindByEmailAsync(employee.WorkEmail);

            employee.Name = employeeDto.Name;
            employee.Surname = employeeDto.Surname;
            employee.PersonalEmail = employeeDto.PersonalEmail;
            employee.WorkEmail = employeeDto.WorkEmail;
            employee.TelephoneNumber = employeeDto.TelephoneNumber;
            employee.Birthday = employeeDto.Birthday;
            employee.Skype = employeeDto.Skype;
            employee.StartDate = employeeDto.StartDate;
            employee.EmployeeStatusId = employeeDto.EmployeeStatusId;
            employee.EndDate = employeeDto.EndDate;
            employee.JobTitleId = employeeDto.JobTitleId;
            employee.Balance = employeeDto.Balance;
            employee.TeamId = employeeDto.TeamId;

            _context.Employee.Update(employee);

            user.UserName = employeeDto.WorkEmail;

            user.Email = employeeDto.WorkEmail;

            var result1 = await _context.SaveChangesAsync();

            var result2 = await _userManager.UpdateAsync(user);

            foreach (var role in await _userManager.GetRolesAsync(user))
            {
                var result3 = await _userManager.RemoveFromRoleAsync(user, role);
            }

            //TODO: Add role
            var result4 = await _roleManager.FindByIdAsync(employeeDto.RoleId);

            if (result4 != null)
            {
                await _userManager.AddToRoleAsync(user, result4.Name);
            }

            return result1;
        }

        public async Task<int> PostAsync(EmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                EmployeeId = Guid.NewGuid(),
                Name = employeeDto.Name,
                Surname = employeeDto.Surname,
                PersonalEmail = employeeDto.PersonalEmail,
                WorkEmail = employeeDto.WorkEmail,
                TelephoneNumber = employeeDto.TelephoneNumber,
                Birthday = employeeDto.Birthday,
                Skype = employeeDto.Skype,
                StartDate = employeeDto.StartDate,
                EmployeeStatusId = employeeDto.EmployeeStatusId,
                EndDate = employeeDto.EndDate,
                JobTitleId = employeeDto.JobTitleId,
                Balance = employeeDto.Balance,
                TeamId = employeeDto.TeamId
            };

            await _context.Employee.AddAsync(employee);

            var user = new User
            {
                UserName = employeeDto.WorkEmail,
                Email = employeeDto.WorkEmail,
                EmployeeId = employee.EmployeeId
            };

            var result1 = await _context.SaveChangesAsync();

            var result2 = await _userManager.CreateAsync(user, "asd123Q!");

            //TODO: Add role
            var result3 = await _roleManager.FindByIdAsync(employeeDto.RoleId);

            if (result3 == null)
            {
                await _userManager.AddToRoleAsync(user, "Employee");
            }
            else
            {
                await _userManager.AddToRoleAsync(user, result3.Name);
            }

            await _usersService.ForgotPassword(user.Email);

            return result1;
        }
    }
}