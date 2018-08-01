using System;
using System.Collections.Generic;

namespace Vacations.BLL.Models
{
    public class TransactionDto
    {
        public Guid TransactionId { get; set; }
        public Guid? TransactionTypeId { get; set; }
        public Guid? EmployeeId { get; set; }
        public int? Days { get; set; }
        public string Сomment { get; set; }

        public EmployeeDto Employee { get; set; }
        public TransactionTypeDto TransactionType { get; set; }
    }
}
