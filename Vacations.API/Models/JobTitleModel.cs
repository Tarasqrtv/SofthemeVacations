using System;
using System.Collections.Generic;

namespace Vacations.API.Models
{
    public partial class JobTitleModel
    {
        public JobTitleModel()
        {
            Employee = new HashSet<EmployeeModel>();
        }

        public Guid JobTitleId { get; set; }
        public string Name { get; set; }

        public ICollection<EmployeeModel> Employee { get; set; }
    }
}
