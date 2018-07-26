using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vacations.BLL.Models;
using Vacations.BLL.Services;
using Vacations.DAL.Models;

namespace Vacations.BLL.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IMapper _mapper;
        private readonly VacationsDbContext _context;

        public EmployeesService(VacationsDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public EmployeeDto GetById(Guid idGuid)
        {
            var employee = _context.Employee.FirstOrDefault(e => e.EmployeeId == idGuid);
            return _mapper.Map<Employee, EmployeeDto>(employee);
        }

        public async Task<EmployeeDto> GetByIdAsync(Guid idGuid)
        {
            var employee = await _context.Employee.FirstOrDefaultAsync(e => e.EmployeeId == idGuid);
            return _mapper.Map<Employee, EmployeeDto>(employee);
        }
    }
}
