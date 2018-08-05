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
        private readonly IUsersService _usersService;
        private readonly IImagesService _imagesService;

        public EmployeesService(
            VacationsDbContext context,
            IMapper mapper,
            IUsersService usersService,
            IImagesService imagesService
            )
        {
            _mapper = mapper;
            _context = context;
            _usersService = usersService;
            _imagesService = imagesService;
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



            if (employee == null)
            {
                return null;
            }

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
                TeamLeadName = employee.Team?.TeamLead?.Name,
                TeamLeadSurname = employee.Team?.TeamLead?.Surname,
                Balance = employee.Balance,
                EmployeeStatusId = employee.EmployeeStatusId,
                JobTitleId = employee.JobTitleId,
                TeamId = employee.TeamId,
                TeamLeadId = employee.Team?.TeamLead?.EmployeeId,
                RoleId = await _usersService.GetUserRoleId(employee.User),
                ImgUrl = employee.ImgUrl
            };
        }

        public async Task<int> PutAsync(EmployeeDto employeeDto)
        {
            var employee = await _context.Employee.FindAsync(employeeDto.EmployeeId);

            var user = await _usersService.FindByEmailAsync(employee.WorkEmail);

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

            if (employee.Balance != employeeDto.Balance)
            {
            }
            else
            {
                employee.Balance = employeeDto.Balance;
            }
            employee.TeamId = employeeDto.TeamId;
            employee.ImgUrl = await _imagesService.GetUrlAsync(employeeDto.ImgUrl);

            _context.Employee.Update(employee);

            user.UserName = employeeDto.WorkEmail;

            user.Email = employeeDto.WorkEmail;

            var result1 = await _context.SaveChangesAsync();

            await _usersService.UpdateUser(user);

            await _usersService.UpdateUserRole(user, employeeDto.RoleId);

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
                TeamId = employeeDto.TeamId,
                ImgUrl = await _imagesService.GetUrlAsync(employeeDto.ImgUrl)
            };

            await _context.Employee.AddAsync(employee);

            var user = new User
            {
                UserName = employeeDto.WorkEmail,
                Email = employeeDto.WorkEmail,
                EmployeeId = employee.EmployeeId
            };

            var result1 = await _context.SaveChangesAsync();

            await _usersService.CreateAsync(user, "asd123Q!");

            await _usersService.SetUserRole(user, employeeDto.RoleId);

            await _usersService.ForgotPassword(user.Email);

            return result1;
        }
    }
}