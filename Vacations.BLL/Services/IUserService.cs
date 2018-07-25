using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacations.BLL.Models;

namespace Vacations.BLL.Services
{
    public interface IUsersService
    {
        UserDto GetByEmail(string email);
        Task<UserDto> GetByEmailAsync(string email);
    }
}
