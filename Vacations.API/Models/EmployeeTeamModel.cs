using System;
using System.Collections.Generic;
using System.Text;

namespace Vacations.API.Models
{
    public class EmployeeTeamModel
    {
        public Guid EmployeeId { get; set; }
        public EmployeeModel Employee { get; set; }
        public Guid TeamId { get; set; }
        public TeamModel Team { get; set; }
    }
}
