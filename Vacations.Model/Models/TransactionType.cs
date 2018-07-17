using System;
using System.Collections.Generic;

namespace Vacations.Model.Models
{
    public partial class TransactionType
    {
        public TransactionType()
        {
            Transaction = new HashSet<Transaction>();
        }

        public Guid TransactionTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<Transaction> Transaction { get; set; }
    }
}
