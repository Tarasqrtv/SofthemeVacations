using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Vacations.DAL.Models
{
    public partial class User : IdentityUser
    {
        public Guid EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
