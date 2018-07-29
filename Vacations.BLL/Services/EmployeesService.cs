using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vacations.BLL.Models;
using Vacations.BLL.Services;
using Vacations.DAL.Models;

namespace Vacations.BLL.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IMapper _mapper;
        private readonly VacationsDbContext _context;
        private readonly UserManager<User> _userManager;

        public EmployeesService(
            VacationsDbContext context,
            IMapper mapper,
            UserManager<User> userManager
            )
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
        }

        //TODO: Employee to EmployeeDTO
        public IEnumerable<Employee> Get()
        {
            var employees = _context.Employee;
            return employees;
        }

        public EmployeeDto GetById(Guid id)
        {
            var employee = _context.Employee.FirstOrDefault(e => e.EmployeeId == id);

            return new EmployeeDto()
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                Surname = employee.Surname,
                JobTitle = employee.JobTitle.Name,
                EmployeeStatus = employee.EmployeeStatus.Name,
                Birthday = employee.Birthday,
                PersonalEmail = employee.PersonalEmail,
                WorkEmail = employee.WorkEmail,
                TelephoneNumber = employee.TelephoneNumber,
                Skype = employee.Skype,
                StartDate = employee.StartDate,
                EndDate = employee.EndDate,
                TeamName = employee.Team.Name,
                TeamLeadName = employee.Team.TeamLead.Name,
                TeamLeadSurname = employee.Team.TeamLead.Surname,
                Balance = employee.Balance,
                EmployeeStatusId = employee.EmployeeStatusId,
                JobTitleId = employee.JobTitleId,
                TeamId = employee.TeamId,
                TeamLeadId = employee.Team.TeamLead.EmployeeId
            };
        }

        public async Task<EmployeeDto> GetByIdAsync(Guid id)
        {
            var employee = await _context.Employee.Include(e => e.Team.TeamLead).FirstOrDefaultAsync(e => e.EmployeeId == id);

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
                TeamName = employee.Team.Name,
                TeamLeadName = employee.Team.TeamLead.Name,
                TeamLeadSurname = employee.Team.TeamLead.Surname,
                Balance = employee.Balance,
                EmployeeStatusId = employee.EmployeeStatusId,
                JobTitleId = employee.JobTitleId,
                TeamId = employee.TeamId,
                TeamLeadId = employee.Team.TeamLead.EmployeeId
            };
        }

        public async Task<int> PutAsync(EmployeeDto employeeDto)
        {
            var employee = _context.Employee.FindAsync(employeeDto.EmployeeId);
            employee.Result.Name = employeeDto.Name;
            employee.Result.Surname = employeeDto.Surname;
            employee.Result.WorkEmail = employeeDto.WorkEmail;
            employee.Result.TelephoneNumber = employeeDto.TelephoneNumber;
            employee.Result.Birthday = employeeDto.Birthday;
            employee.Result.Skype = employeeDto.Skype;
            employee.Result.StartDate = employeeDto.StartDate;
            employee.Result.EmployeeStatusId = employeeDto.EmployeeStatusId;
            employee.Result.EndDate = employeeDto.EndDate;
            employee.Result.JobTitleId = employeeDto.JobTitleId;
            employee.Result.Balance = employeeDto.Balance;

            _context.Employee.Update(employee.Result);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> PostAsync(EmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                EmployeeId = Guid.NewGuid(),
                Name = employeeDto.Name,
                Surname = employeeDto.Surname,
                WorkEmail = employeeDto.WorkEmail,
                TelephoneNumber = employeeDto.TelephoneNumber,
                Birthday = employeeDto.Birthday,
                Skype = employeeDto.Skype,
                StartDate = employeeDto.StartDate,
                EmployeeStatusId = employeeDto.EmployeeStatusId,
                EndDate = employeeDto.EndDate,
                JobTitleId = employeeDto.JobTitleId,
                Balance = employeeDto.Balance
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
            var result3 = await _userManager.AddToRoleAsync(user, employeeDto.Role.FirstOrDefault());

            return result1;
        }
    }
}