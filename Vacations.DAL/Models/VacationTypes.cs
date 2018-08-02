using System;
using System.Collections.Generic;

namespace Vacations.DAL.Models
{
    public partial class VacationTypes
    {
        public VacationTypes()
        {
            Vacation = new HashSet<Vacation>();
        }

        public Guid VacationTypesId { get; set; }
        public string Name { get; set; }

        public ICollection<Vacation> Vacation { get; set; }
    }
}
