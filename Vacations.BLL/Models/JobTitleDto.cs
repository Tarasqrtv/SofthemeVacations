using System;
using System.Collections.Generic;

namespace Vacations.BLL.Models
{
    public class JobTitleDto
    {
        public JobTitleDto()
        {
            Employee = new HashSet<EmployeeDto>();
        }

        public Guid JobTitleId { get; set; }
        public string Name { get; set; }

        public ICollection<EmployeeDto> Employee { get; set; }
    }
}
