using System;
using System.Collections.Generic;

namespace Vacations.BLL.Models
{
    public partial class TransactionTypeDto
    {
        public TransactionTypeDto()
        {
            Transaction = new HashSet<TransactionDto>();
        }

        public Guid TransactionTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<TransactionDto> Transaction { get; set; }
    }
}
