using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vacations.BLL.Models;
using Vacations.BLL.Services;
using Vacations.DAL.Models;

namespace Vacations.BLL.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IMapper _mapper;
        private readonly VacationsDbContext _context;
        private readonly IUsersService _usersService;

        public TransactionService(
            VacationsDbContext context,
            IMapper mapper,
            IUsersService usersService
            )
        {
            _mapper = mapper;
            _context = context;
            _usersService = usersService;
        }
        public async Task CreateTransactionByVacationAsync(VacationDto vacation, ClaimsPrincipal user)
        {
            var balance = (int)vacation.EndVocationDate.Subtract(vacation.StartVocationDate).TotalDays;

            if (balance <= 0)
            {
                throw new ArgumentOutOfRangeException("Start Date >= End Date");
            }

            var transacrion = new Transaction()
            {
                TransactionId = new Guid(),
                TransactionTypeId = _context.TransactionType.FirstOrDefault(t => t.Name == "ByVacation").TransactionTypeId,
                EmployeeId = vacation.EmployeeId,
                Days = -balance,
                Comment = vacation.TransactionComment,
                AuthorId = (await _usersService.GetUserAsync(user)).EmployeeId,
                VacationId = vacation.VacationId,
                TransactionDate = DateTime.UtcNow
            };

            var employee = _context.Employee.Find(vacation.EmployeeId);

            employee.Balance += transacrion.Days;

            await _context.Transaction.AddAsync(transacrion);

            _context.Employee.Update(employee);

            await _context.SaveChangesAsync();
        }

        public async Task CreateTransactionByAdminAsync(Guid EmployeeId, int balance, ClaimsPrincipal user)
        {
            if (balance == 0)
            {
                return;
            }

            var transacrion = new Transaction()
            {
                TransactionId = new Guid(),
                TransactionTypeId = _context.TransactionType.FirstOrDefault(t => t.Name == "ByAdmin").TransactionTypeId,
                EmployeeId = EmployeeId,
                Days = balance,
                Comment = null,
                AuthorId = (await _usersService.GetUserAsync(user)).EmployeeId,
                VacationId = null,
                TransactionDate = DateTime.UtcNow
            };

            await _context.Transaction.AddAsync(transacrion);

            await _context.SaveChangesAsync();
        }
    }
}
