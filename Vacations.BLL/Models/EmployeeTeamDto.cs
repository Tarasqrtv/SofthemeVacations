using System;
using System.Collections.Generic;
using System.Text;

namespace Vacations.BLL.Models
{
    public class EmployeeTeamDto
    {
        public Guid EmployeeId { get; set; }
        public EmployeeDto Employee { get; set; }
        public Guid TeamId { get; set; }
        public TeamDto Team { get; set; }
    }
}
