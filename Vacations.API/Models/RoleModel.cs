using System;
using System.Collections.Generic;

namespace Vacations.API.Models
{
    public partial class RoleModel
    {
        public RoleModel()
        {
            User = new HashSet<UserModel>();
        }

        public Guid RoleId { get; set; }
        public string Name { get; set; }

        public ICollection<UserModel> User { get; set; }
    }
}
