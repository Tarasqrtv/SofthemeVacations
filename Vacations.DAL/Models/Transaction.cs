﻿using System;
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

        public Employee Employee { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}
