using System;
using System.Collections.Generic;

namespace Vacations.API.Models
{
    public partial class TransactionTypeModel
    {
        public TransactionTypeModel()
        {
            Transaction = new HashSet<TransactionModel>();
        }

        public Guid TransactionTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<TransactionModel> Transaction { get; set; }
    }
}
