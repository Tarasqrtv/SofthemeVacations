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
    public class UsersService : IUsersService
    {
        private readonly IMapper _mapper;
        private readonly VacationsDbContext _context;

        public UsersService(VacationsDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public UserDto GetByEmail(string email)
        {
            var user = _context.User.FirstOrDefault(x => x.PersonalEmail == email);
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<UserDto> GetByEmailAsync(string email)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.PersonalEmail == email);
            return _mapper.Map<User, UserDto>(user);
        }
    }
}
