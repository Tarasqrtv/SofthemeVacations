using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
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

        public EmployeesService(VacationsDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public EmployeeDto GetById(Guid id)
        {
           var employee = _context.Employee.Include(e => e.Team);

           return employee.Where(e => e.EmployeeId == id)
                .Select(e => new EmployeeDto()
                {
                    EmployeeId = e.EmployeeId,
                    Name = e.Name,
                    Surname = e.Surname,
                    JobTitle = e.JobTitle.Name,
                    EmployeeStatus = e.EmployeeStatus.Name,
                    Birthday = e.Birthday,
                    PersonalEmail = e.WorkEmail,
                    WorkEmail = e.WorkEmail,
                    TelephoneNumber = e.TelephoneNumber,
                    Skype = e.Skype,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    TeamName = e.EmployeeTeam.Select(t => t.Team.Name).FirstOrDefault(),
                    TeamLeadName = e.EmployeeTeam.Select(t => t.Team.TeamLead.Name).FirstOrDefault(),
                    TeamLeadSurname = e.EmployeeTeam.Select(t => t.Team.TeamLead.Surname).FirstOrDefault(),
                    Balance = e.Balance,
                    EmployeeStatusId = e.EmployeeStatusId,
                    JobTitleId = e.JobTitleId,
                    TeamId = e.EmployeeTeam.Select(t => t.Team.TeamId).FirstOrDefault(),
                    TeamLeadId = e.EmployeeTeam.Select(t => t.Team.TeamLeadId).FirstOrDefault()
                })
                .FirstOrDefault();

        }

        public async Task<EmployeeDto> GetByIdAsync(Guid id)
        {
            var employee = _context.Employee.Include(e => e.Team);

            return await employee.Where(e => e.EmployeeId == id)
                .Select(e => new EmployeeDto()
                {
                    EmployeeId = e.EmployeeId,
                    Name = e.Name,
                    Surname = e.Surname,
                    JobTitle = e.JobTitle.Name,
                    EmployeeStatus = e.EmployeeStatus.Name,
                    Birthday = e.Birthday,
                    PersonalEmail = e.WorkEmail,
                    WorkEmail = e.WorkEmail,
                    TelephoneNumber = e.TelephoneNumber,
                    Skype = e.Skype,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    TeamName = e.EmployeeTeam.Select(t => t.Team.Name).FirstOrDefault(),
                    TeamLeadName = e.EmployeeTeam.Select(t => t.Team.TeamLead.Name).FirstOrDefault(),
                    TeamLeadSurname = e.EmployeeTeam.Select(t => t.Team.TeamLead.Surname).FirstOrDefault(),
                    Balance = e.Balance,
                    EmployeeStatusId = e.EmployeeStatusId,
                    JobTitleId = e.JobTitleId,
                    TeamId = e.EmployeeTeam.Select(t => t.Team.TeamId).FirstOrDefault(),
                    TeamLeadId = e.EmployeeTeam.Select(t => t.Team.TeamLeadId).FirstOrDefault()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<int> PutAsync(EmployeeDto employeeDto)
        {
            var employee = _context.Employee.FindAsync(employeeDto.EmployeeId);
            employee.Result.Name = employeeDto.Name;
            employee.Result.Balance = employeeDto.Balance;
            employee.Result.Birthday = employeeDto.Birthday;
            employee.Result.EmployeeStatusId = employeeDto.EmployeeStatusId;

            _context.Employee.Update(employee.Result);
            return await _context.SaveChangesAsync();
        }
    }
}
