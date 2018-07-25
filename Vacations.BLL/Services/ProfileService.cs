using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vacations.BLL.Models;
using Vacations.DAL.Models;

namespace Vacations.BLL.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IMapper _mapper;
        private readonly VacationsDbContext _context;

        public ProfileService(VacationsDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public ProfileDto GetById(Guid idGuid)
        {
            var profile = _context.Employee.Include(e => e.Team)
                .Where(e => e.EmployeeId == idGuid)
                .Select(e => new ProfileDto()
                {
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
                    Balance = e.Balance
                })
                .FirstOrDefault();

            return profile;
        }

        public async Task<ProfileDto> GetByIdAsync(Guid idGuid)
        {
            var profile = await _context.Employee.Include(e => e.Team)
                .Where(e => e.EmployeeId == idGuid)
                .Select(e => new ProfileDto()
                {
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
                    Balance = e.Balance
                })
                .FirstOrDefaultAsync();

            return profile;
        }
    }
}
