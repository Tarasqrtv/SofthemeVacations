using System;
using System.Collections.Generic;

namespace Vacations.DAL.Models
{
    public partial class EmployeeStatus
    {
        public EmployeeStatus()
        {
            Employee = new HashSet<Employee>();
        }

        public Guid EmployeeStatusId { get; set; }
        public string Name { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
