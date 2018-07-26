using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
