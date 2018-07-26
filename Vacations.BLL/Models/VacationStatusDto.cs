using System;
using System.Collections.Generic;

namespace Vacations.BLL.Models
{
    public partial class VacationStatusDto
    {
        public VacationStatusDto()
        {
            Vacation = new HashSet<VacationDto>();
        }

        public Guid VacationStatusId { get; set; }
        public string Name { get; set; }

        public ICollection<VacationDto> Vacation { get; set; }
    }
}
