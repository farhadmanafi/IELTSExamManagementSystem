using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Accounting.Domain.Contracts.AccountingAggregate
{
    public class BankTransactionDto
    {
        public Guid ParticipantsId { get; set; }
        public Guid BankTransactionTypeId { get; set; }
        public Guid ExamTypeId { get; set; }
        public DateTime PaymentDateTime { get; set; }
        public long PaymentPriceAmount { get; set; }
        public string BankTransactionCode { get; set; }
        public string CustomerAccountNumber { get; set; }
        public bool PaymentFinished { get; set; }
        public string BankName { get; set; }
        public Guid CustomerId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
