using System;
using System.Collections.Generic;

namespace Vacations.BLL.Models
{
    public partial class RoleDto
    {
        public RoleDto()
        {
            User = new HashSet<UserDto>();
        }

        public Guid RoleId { get; set; }
        public string Name { get; set; }

        public ICollection<UserDto> User { get; set; }
    }
}
