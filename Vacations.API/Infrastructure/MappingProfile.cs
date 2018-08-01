using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Vacations.BLL.Models;
using Vacations.DAL.Models;

namespace Vacations.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, ProfileDto>()
                .ForMember(p => p.TeamName, o => o.MapFrom(e => e.Team.Name))
                .ForMember(p => p.TeamLeadName, o=> o.MapFrom(e => e.Team.TeamLead.Name))
                .ForMember(p => p.TeamLeadSurname, o => o.MapFrom(e => e.Team.TeamLead.Surname))
                .ForMember(p => p.JobTitle, o => o.MapFrom(e => e.JobTitle.Name))
                .ForMember(p => p.EmployeeStatus, o => o.MapFrom(e => e.EmployeeStatus.Name));

            CreateMap<Vacation, VacationDto>()
                .ForMember(vdto => vdto.VacationStatusName, o => o.MapFrom(v => v.VacationStatus.Name));
        }
    }
}
