using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacations.BLL.Models;

namespace Vacations.BLL.Services
{
    public interface IEmployeeStatusService
    {
        EmployeeStatusDto GetById(Guid idGuid);
        Task<EmployeeStatusDto> GetByIdAsync(Guid idGuid);

        IEnumerable<EmployeeStatusDto> Get();
    }
}