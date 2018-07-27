using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacations.BLL.Models;

namespace Vacations.BLL.Services
{
    public interface ITeamsService
    {
        TeamDto GetById(Guid idGuid);
        Task<TeamDto> GetByIdAsync(Guid idGuid);

        IEnumerable<TeamDto> Get();
    }
}