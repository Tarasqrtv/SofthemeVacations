using System;
using System.Collections.Generic;

namespace Vacations.BLL.Models
{
    public partial class EmployeeDto
    {
        public EmployeeDto()
        {
            Team = new HashSet<TeamDto>();
            Transaction = new HashSet<TransactionDto>();
            Vacation = new HashSet<VacationDto>();
        }

        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string WorkEmail { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public string Skype { get; set; }
        public DateTime? StartDate { get; set; }
        public Guid? EmployeeStatusId { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid? JobTitleId { get; set; }
        public int? Balance { get; set; }

        public EmployeeStatusDto EmployeeStatus { get; set; }
        public JobTitleDto JobTitle { get; set; }
        public UserDto User { get; set; }
        public ICollection<TeamDto> Team { get; set; }
        public ICollection<TransactionDto> Transaction { get; set; }
        public ICollection<VacationDto> Vacation { get; set; }
        public ICollection<EmployeeTeamDto> EmployeeTeam { get; set; }
    }
}
