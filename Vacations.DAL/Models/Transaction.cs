using System;
using System.Collections.Generic;

namespace Vacations.DAL.Models
{
    public partial class Transaction
    {
        public Guid TransactionId { get; set; }
        public Guid TransactionTypeId { get; set; }
        public Guid EmployeeId { get; set; }
        public int Days { get; set; }
        public string Comment { get; set; }
        public Guid? AuthorId { get; set; }
        public Guid? VacationId { get; set; }
        public DateTime? TransactionDate { get; set; }

        public Employee Author { get; set; }
        public Employee Employee { get; set; }
        public TransactionType TransactionType { get; set; }
        public Vacation Vacation { get; set; }
    }
}
