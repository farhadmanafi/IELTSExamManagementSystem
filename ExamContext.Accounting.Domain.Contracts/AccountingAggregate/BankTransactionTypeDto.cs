using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Accounting.Domain.Contracts.AccountingAggregate
{
    public class BankTransactionTypeDto
    {
        public string Title { get; set; }
        public int OrderNo { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
