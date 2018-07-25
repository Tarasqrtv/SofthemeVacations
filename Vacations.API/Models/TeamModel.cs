using System;
using System.Collections.Generic;

namespace Vacations.API.Models
{
    public partial class TeamModel
    {
        public Guid TeamId { get; set; }
        public Guid? TeamLeadId { get; set; }
        public string Name { get; set; }

        public EmployeeModel TeamLead { get; set; }
        public ICollection<EmployeeTeamModel> EmployeeTeam { get; set; }
    }
}
