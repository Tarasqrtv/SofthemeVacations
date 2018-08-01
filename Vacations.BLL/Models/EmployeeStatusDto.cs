using System;
using System.Collections.Generic;

namespace Vacations.BLL.Models
{
    public class EmployeeStatusDto
    {
        public EmployeeStatusDto()
        {
            Employee = new HashSet<EmployeeDto>();
        }

        public Guid EmployeeStatusId { get; set; }
        public string Name { get; set; }

        public ICollection<EmployeeDto> Employee { get; set; }
    }
}
