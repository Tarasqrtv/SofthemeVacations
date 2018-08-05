using System;
using System.Collections.Generic;

namespace Vacations.DAL.Models
{
    public partial class Vacation
    {
        public Vacation()
        {
            Transaction = new HashSet<Transaction>();
        }

        public Guid VacationId { get; set; }
        public DateTime StartVocationDate { get; set; }
        public DateTime EndVocationDate { get; set; }
        public Guid VacationStatusId { get; set; }
        public string Comment { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid VacationTypesId { get; set; }

        public Employee Employee { get; set; }
        public VacationStatus VacationStatus { get; set; }
        public VacationTypes VacationTypes { get; set; }
        public ICollection<Transaction> Transaction { get; set; }
    }
}
