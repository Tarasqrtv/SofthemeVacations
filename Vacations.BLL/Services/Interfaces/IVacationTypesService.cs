using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vacations.BLL.Models;

namespace Vacations.BLL.Services
{
    public interface IVacationTypesService
    {
        VacationTypesDto GetById(Guid idGuid);
        Task<VacationTypesDto> GetByIdAsync(Guid idGuid);

        IEnumerable<VacationTypesDto> Get();
    }
}