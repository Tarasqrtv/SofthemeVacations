using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vacations.BLL.Models;
using Vacations.DAL.Models;

namespace Vacations.BLL.Services
{
    public class VacationsService : IVacationsService
    {
        private readonly IMapper _mapper;
        private readonly VacationsDbContext _context;
        private readonly IUsersService _usersService;
        private readonly IVacationStatusService _vacationStatusService;
        private readonly UserManager<User> _userManager;
        private readonly IEmployeesService _employeesService;
        private readonly ITransactionService _transactionService;

        public VacationsService(
            VacationsDbContext context,
            IMapper mapper,
            IUsersService usersService,
            IVacationStatusService vacationStatusService,
            UserManager<User> userManager,
            IEmployeesService employeesService,
            ITransactionService transactionService
            )
        {
            _mapper = mapper;
            _context = context;
            _usersService = usersService;
            _vacationStatusService = vacationStatusService;
            _userManager = userManager;
            _employeesService = employeesService;
            _transactionService = transactionService;
        }


        public VacationDto GetById(Guid idGuid)
        {
            var vacation = _context.Vacation
                .Include(v => v.VacationStatus)
                .Include(v => v.VacationTypes)
                .Include(v => v.Employee.Team)
                .Include(v => v.Employee)
                .FirstOrDefault(v => v.VacationId == idGuid);

            return _mapper.Map<Vacation, VacationDto>(vacation);
        }

        public async Task<VacationDto> GetByIdAsync(Guid idGuid)
        {
            var vacation = await _context.Vacation
                .Include(v => v.VacationStatus)
                .Include(v => v.VacationTypes)
                .Include(v => v.Employee.Team)
                .Include(v => v.Employee)
                .FirstOrDefaultAsync(v => v.VacationId == idGuid);

            return _mapper.Map<Vacation, VacationDto>(vacation);
        }

        public IEnumerable<VacationDto> Get()
        {
            var vacations = _context.Vacation
                .Include(v => v.VacationStatus)
                .Include(v => v.VacationTypes)
                .Include(v => v.Employee.Team)
                .Include(v => v.Employee);

            return _mapper.Map<IEnumerable<Vacation>, IEnumerable<VacationDto>>(vacations);
        }

        private IEnumerable<VacationDto> GetTeamleadVacationRequests(User currentUser)
        {
            var employees = _context.Employee
                .Include(t => t.Team)
                .Where(e => e.Team.TeamLeadId == currentUser.EmployeeId);

            var vacations = _context.Vacation
                .Include(v => v.VacationStatus)
                .Include(v => v.VacationTypes)
                .Include(v => v.Employee.Team)
                .Include(v => v.Employee)
                .Join(employees, v => v.EmployeeId, e => e.EmployeeId,
                    (v, e) => v);

            return _mapper.Map<IEnumerable<Vacation>, IEnumerable<VacationDto>>(vacations);
        }

        private IEnumerable<VacationDto> GetAdminVacationRequests(User currentUser)
        {
            var employees = _context.Employee
                .Include(t => t.Team)
                .Where(e => e.Team.TeamLeadId == currentUser.EmployeeId
                            || e.TeamId == null
                            || e.EmployeeId == e.Team.TeamLeadId);

            var vacations = _context.Vacation
                .Include(v => v.VacationStatus)
                .Include(v => v.VacationTypes)
                .Include(v => v.Employee.Team)
                .Include(v => v.Employee)
                .Join(employees, v => v.EmployeeId, e => e.EmployeeId,
                    (v, e) => v);

            return _mapper.Map<IEnumerable<Vacation>, IEnumerable<VacationDto>>(vacations);
        }

        public async Task<IEnumerable<VacationDto>> GetByCurrentEmployeeIdAsync(ClaimsPrincipal user)
        {
            var currentUser = await _usersService.GetUserAsync(user);

            return GetByEmployeeId(currentUser.EmployeeId);
        }

        public IEnumerable<VacationDto> GetByEmployeeId(Guid idGuid)
        {
            var vacations = _context.Vacation
                .Include(v => v.VacationStatus)
                .Include(v => v.Employee.Team)
                .Include(v => v.Employee)
                .Where(v => v.EmployeeId == idGuid);

            return _mapper.Map<IEnumerable<Vacation>, IEnumerable<VacationDto>>(vacations);
        }

        public async Task PutAsync(VacationDto vacationDto, ClaimsPrincipal user)
        {
            if (vacationDto.VacationStatusId == null)
            {
                throw new ArgumentException("");
            }

            var vacation = new Vacation
            {
                VacationId = vacationDto.VacationId,
                StartVocationDate = vacationDto.StartVocationDate,
                EndVocationDate = vacationDto.EndVocationDate,
                VacationStatusId = vacationDto.VacationStatusId ?? new Guid(),
                VacationTypesId = vacationDto.VacationTypesId,
                Comment = vacationDto.Comment,
                EmployeeId = vacationDto.EmployeeId,
            };

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {

                _context.Vacation.Update(vacation);

                if (vacation.VacationStatusId == _vacationStatusService.Get().FirstOrDefault(vs => vs.Name == "Approved").VacationStatusId)
                {
                    await _transactionService.CreateTransactionByVacationAsync(vacationDto, user);
                }

                await _context.SaveChangesAsync();

                scope.Complete();
            }
        }

        public async Task PostCurrentAsync(ClaimsPrincipal user, VacationDto vacationDto)
        {
            var currentUser = await _usersService.GetUserAsync(user);

            vacationDto.EmployeeId = currentUser.EmployeeId;

            if (_vacationStatusService != null)
                vacationDto.VacationStatusId = _vacationStatusService.Get().FirstOrDefault(vs => vs.Name == "InProcess")
                    .VacationStatusId;

            if (vacationDto.VacationStatusId == null)
            {
                throw new ArgumentException("");
            }

            _context.Vacation.Add(_mapper.Map<VacationDto, Vacation>(vacationDto));

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<VacationDto>> GetVacationRequestsAsync(ClaimsPrincipal user)
        {
            var currentUser = await _usersService.GetUserAsync(user);

            foreach (var role in await _userManager.GetRolesAsync(currentUser))
            {
                if (role == "Admin")
                {
                    return GetAdminVacationRequests(currentUser);
                }
                if (role == "TeamLead")
                {
                    return GetTeamleadVacationRequests(currentUser);
                }
            }

            return null;
        }
    }
}