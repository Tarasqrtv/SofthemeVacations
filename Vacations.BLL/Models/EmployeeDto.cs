using System;
using System.Collections.Generic;

namespace Vacations.BLL.Models
{
    public partial class EmployeeDto
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string WorkEmail { get; set; }
        public string PersonalEmail { get; set; }
        public string TelephoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public string Skype { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Balance { get; set; }
        public string TeamName { get; set; }
        public string TeamLeadName { get; set; }
        public string TeamLeadSurname { get; set; }
        public Guid? EmployeeStatusId { get; set; }
        public Guid? JobTitleId { get; set; }
        public Guid? TeamId { get; set; }
        public Guid? TeamLeadId { get; set; }
        public string Role { get; set; }
    }
}
