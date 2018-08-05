using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Vacations.BLL.Models;

namespace Vacations.BLL.Services
{
    public interface IVacationsService
    {
        VacationDto GetById(Guid idGuid);

        Task<VacationDto> GetByIdAsync(Guid idGuid);

        IEnumerable<VacationDto> Get();

        IEnumerable<VacationDto> GetByEmployeeId(Guid idGuid);

        Task<IEnumerable<VacationDto>> GetByCurrentEmployeeIdAsync(ClaimsPrincipal user);

        Task PutAsync(VacationDto employeeDto, ClaimsPrincipal user);

        Task PostCurrentAsync(ClaimsPrincipal user, VacationDto vacationDto);

        Task<IEnumerable<VacationDto>> GetVacationRequestsAsync(ClaimsPrincipal user);
    }
}