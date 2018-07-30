using System;
using System.Collections.Generic;

namespace Vacations.DAL.Models
{
    public partial class Team
    {
        public Team()
        {
            Employee = new HashSet<Employee>();
        }

        public Guid TeamId { get; set; }
        public Guid? TeamLeadId { get; set; }
        public string Name { get; set; }

        public Employee TeamLead { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
}
