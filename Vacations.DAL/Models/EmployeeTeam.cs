using System;
using System.Collections.Generic;
using System.Text;

namespace Vacations.DAL.Models
{
    public class EmployeeTeam
    {
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public Guid TeamId { get; set; }
        public Team Team { get; set; }
    }
}
