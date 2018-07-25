using System;
using System.Collections.Generic;

namespace Vacations.API.Models
{
    public partial class TransactionModel
    {
        public Guid TransactionId { get; set; }
        public Guid? TransactionTypeId { get; set; }
        public Guid? EmployeeId { get; set; }
        public int? Days { get; set; }
        public string Сomment { get; set; }

        public EmployeeModel Employee { get; set; }
        public TransactionTypeModel TransactionType { get; set; }
    }
}
