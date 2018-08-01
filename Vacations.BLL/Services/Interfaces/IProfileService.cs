using System;
using System.Threading.Tasks;
using Vacations.BLL.Models;

namespace Vacations.BLL.Services
{
    public interface IProfileService
    {
        Task<ProfileDto> GetByIdAsync(Guid idGuid);
    }
}
