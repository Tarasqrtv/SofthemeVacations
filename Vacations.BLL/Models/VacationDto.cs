using System;
using System.Collections.Generic;

namespace Vacations.BLL.Models
{
    public class VacationDto
    {
        public Guid VacationId { get; set; }
        public DateTime? StartVocationDate { get; set; }
        public DateTime? EndVocationDate { get; set; }
        public Guid? VacationStatusId { get; set; }
        public string Comment { get; set; }
        public Guid? EmployeeId { get; set; }
        public string VacationStatusName { get; set; }
    }
}
