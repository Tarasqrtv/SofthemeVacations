using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Vacations.DAL.Models
{
    public class User : IdentityUser
    {
//        [Required]
        public Guid EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
