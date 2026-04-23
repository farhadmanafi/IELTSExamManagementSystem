using System;
using System.Collections.Generic;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class BankTransaction
    {
        public Guid Id { get; set; }
        public Guid ParticipantsId { get; set; }
        public DateTime PaymentDateTime { get; set; }
        public long PaymentPriceAmount { get; set; }
        public string BankTransactionCode { get; set; }
        public string CustomerAccountNumber { get; set; }
        public bool PaymentFinished { get; set; }
        public string BankName { get; set; }
        public Guid CustomerId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Guid BankTransactionTypeId { get; set; }
        public Guid ExamTypeId { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual BankTransactionType BankTransactionType { get; set; }
        public virtual ExamType ExamType { get; set; }
    }
}
