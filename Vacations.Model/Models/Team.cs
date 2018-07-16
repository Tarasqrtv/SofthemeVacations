using System;
using System.Collections.Generic;

namespace Vacations.Model.Models
{
    public partial class Team
    {
        public Guid TeamId { get; set; }
        public Guid? TeamLeadId { get; set; }
        public string Name { get; set; }

        public Employee TeamLead { get; set; }
    }
}
