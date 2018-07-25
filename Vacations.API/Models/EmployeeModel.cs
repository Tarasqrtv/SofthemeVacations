using System;
using System.Collections.Generic;

namespace Vacations.API.Models
{
    public partial class EmployeeModel
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string WorkEmail { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public string Skype { get; set; }
        public DateTime? StartDate { get; set; }
        public Guid? EmployeeStatusId { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid? JobTitleId { get; set; }
        public int? Balance { get; set; }
    }
}
