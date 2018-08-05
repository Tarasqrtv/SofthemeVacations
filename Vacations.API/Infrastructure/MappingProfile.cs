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
            AllowNullCollections = true;

            CreateMap<Employee, ProfileDto>()
                .ForMember(p => p.TeamName, o => o.MapFrom(e => e.Team.Name))
                .ForMember(p => p.TeamLeadName, o=> o.MapFrom(e => e.Team.TeamLead.Name))
                .ForMember(p => p.TeamLeadSurname, o => o.MapFrom(e => e.Team.TeamLead.Surname))
                .ForMember(p => p.JobTitle, o => o.MapFrom(e => e.JobTitle.Name))
                .ForMember(p => p.ImgUrl, o => o.MapFrom(e => e.ImgUrl))
                .ForMember(p => p.EmployeeStatus, o => o.MapFrom(e => e.EmployeeStatus.Name));

            CreateMap<Vacation, VacationDto>()
                .ForMember(vdto => vdto.EmployeeName, o => o.MapFrom(v => v.Employee.Name))
                .ForMember(vdto => vdto.EmployeeSurname, o => o.MapFrom(v => v.Employee.Surname))
                .ForMember(vdto => vdto.EmployeeBalance, o => o.MapFrom(v => v.Employee.Balance))
                .ForMember(vdto => vdto.VacationStatusName, o => o.MapFrom(v => v.VacationStatus.Name))
                .ForMember(vdto => vdto.TeamName, o => o.MapFrom(v => v.Employee.Team.Name))
                .ForMember(vdto => vdto.VacationTypeName, o => o.MapFrom(v => v.VacationTypes.Name));

            CreateMap<Team, TeamDto>()
                .ForMember(tdto => tdto.TeamLeadName, o => o.MapFrom(t => t.TeamLead.Name))
                .ForMember(tdto => tdto.TeamLeadSurname, o => o.MapFrom(t => t.TeamLead.Surname));
        }
    }
}
