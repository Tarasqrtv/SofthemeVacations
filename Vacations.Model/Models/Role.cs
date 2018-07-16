using System;
using System.Collections.Generic;

namespace Vacations.Model.Models
{
    public partial class Role
    {
        public Role()
        {
            User = new HashSet<User>();
        }

        public Guid RoleId { get; set; }
        public string Name { get; set; }

        public ICollection<User> User { get; set; }
    }
}
