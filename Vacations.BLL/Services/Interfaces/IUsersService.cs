using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vacations.BLL.Models;
using Vacations.DAL.Models;

namespace Vacations.BLL.Services
{
    public interface IUsersService
    {
        Task<string> GenerateJwtTokenAsync(string email, User user);
        Task<TokenDto> GetTokenAsync(string authorizationHeader);
        Task ForgotPassword(string email);
    }
}
