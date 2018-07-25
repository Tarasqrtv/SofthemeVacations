using System;
using System.Collections.Generic;

namespace Vacations.DAL.Models
{
    public partial class VacationStatus
    {
        public VacationStatus()
        {
            Vacation = new HashSet<Vacation>();
        }

        public Guid VacationStatusId { get; set; }
        public string Name { get; set; }

        public ICollection<Vacation> Vacation { get; set; }
    }
}
