using ExamContext.Accounting.Domain.Contracts.AccountingAggregate;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Accounting.Domain.AccountingAggregate
{
    public class BankTransactionType : EntityBase
    {
        public BankTransactionType()
        {

        }
        public BankTransactionType(BankTransactionTypeDto dto)
        {
            Title = dto.Title;
            OrderNo = dto.OrderNo;
            Description = dto.Description;
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
        }
        public string Title { get; set; }
        public int OrderNo { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<BankTransaction> BankTransactionList { get; set; }
    }
}
