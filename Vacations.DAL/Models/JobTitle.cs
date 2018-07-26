using System;
using System.Collections.Generic;

namespace Vacations.DAL.Models
{
    public partial class JobTitle
    {
        public JobTitle()
        {
            Employee = new HashSet<Employee>();
        }

        public Guid JobTitleId { get; set; }
        public string Name { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
