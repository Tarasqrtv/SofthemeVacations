using System;
using System.Collections.Generic;

namespace Vacations.Model.Models
{
    public partial class User
    {
        public Guid UserId { get; set; }
        public Guid? EmployeeId { get; set; }
        public string Password { get; set; }
        public string PersonalEmail { get; set; }
        public Guid? RoleId { get; set; }

        public Employee Employee { get; set; }
        public Role Role { get; set; }
    }
}
