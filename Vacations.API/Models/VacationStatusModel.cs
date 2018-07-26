using System;
using System.Collections.Generic;

namespace Vacations.API.Models
{
    public partial class VacationStatusModel
    {
        public VacationStatusModel()
        {
            Vacation = new HashSet<VacationModel>();
        }

        public Guid VacationStatusId { get; set; }
        public string Name { get; set; }

        public ICollection<VacationModel> Vacation { get; set; }
    }
}
