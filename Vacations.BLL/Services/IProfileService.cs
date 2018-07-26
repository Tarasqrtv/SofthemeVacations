using System;
using System.Threading.Tasks;
using Vacations.BLL.Models;

namespace Vacations.BLL.Services
{
    public interface IProfileService
    {
        ProfileDto GetById(Guid idGuid);
        Task<ProfileDto> GetByIdAsync(Guid idGuid);
    }
}
