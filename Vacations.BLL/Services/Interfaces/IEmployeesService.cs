using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Vacations.BLL.Models;
using Vacations.DAL.Models;

namespace Vacations.BLL.Services
{
    public interface IEmployeesService
    {
        IEnumerable<EmployeeDtoList> Get();
        Task<EmployeeDto> GetByIdAsync(Guid id);
        Task PutAsync(EmployeeDto employeeDto, ClaimsPrincipal admin);
        Task PostAsync(EmployeeDto employeeDto, ClaimsPrincipal admin);
    }
}
