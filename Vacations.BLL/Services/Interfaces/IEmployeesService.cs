using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacations.BLL.Models;

namespace Vacations.BLL.Services
{
    public interface IEmployeesService
    {
        EmployeeDto GetById(Guid id);
        Task<EmployeeDto> GetByIdAsync(Guid id);
        Task<int> PutAsync(EmployeeDto employeeDto);
    }
}
