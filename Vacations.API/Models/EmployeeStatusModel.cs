using System;
using System.Collections.Generic;

namespace Vacations.API.Models
{
    public partial class EmployeeStatusModel
    {
        public EmployeeStatusModel()
        {
            Employee = new HashSet<EmployeeModel>();
        }

        public Guid EmployeeStatusId { get; set; }
        public string Name { get; set; }

        public ICollection<EmployeeModel> Employee { get; set; }
    }
}
