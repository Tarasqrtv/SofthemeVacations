using System;
using System.Collections.Generic;

namespace Vacations.API.Models
{
    public partial class VacationModel
    {
        public Guid VacationId { get; set; }
        public DateTime? StartVocationDate { get; set; }
        public DateTime? EndVocationDate { get; set; }
        public Guid? VacationStatusId { get; set; }
        public string Comment { get; set; }
        public Guid? EmployeeId { get; set; }

        public VacationStatusModel VacationStatus { get; set; }
    }
}
