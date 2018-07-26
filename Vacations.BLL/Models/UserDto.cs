using System;
using System.Collections.Generic;

namespace Vacations.BLL.Models
{
    public partial class UserDto
    {
        public Guid UserId { get; set; }
        public Guid EmployeeId { get; set; }
        public string Password { get; set; }
        public string PersonalEmail { get; set; }
        public Guid? RoleId { get; set; }
    }
}
