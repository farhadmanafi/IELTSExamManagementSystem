using ExamContext.Accounting.Domain.Contracts.AccountingAggregate;
using Framework.Core.Domain;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Accounting.Domain.AccountingAggregate
{
    public class BankTransaction : EntityBase, IAggregateRoot<BankTransaction>
    {
        public BankTransaction()
        {

        }
        public BankTransaction(BankTransactionDto dto)
        {
            ParticipantsId = dto.ParticipantsId;
            BankTransactionTypeId = dto.BankTransactionTypeId;
            ExamTypeId = dto.ExamTypeId;
            PaymentPriceAmount = dto.PaymentPriceAmount;
            BankTransactionCode = dto.BankTransactionCode;
            CustomerAccountNumber = dto.CustomerAccountNumber;
            PaymentFinished = dto.PaymentFinished;
            BankName = dto.BankName;
            CustomerId = dto.CustomerId;
            PaymentDateTime = dto.PaymentDateTime;
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
        }

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
        [ForeignKey("BankTransactionTypeId")]
        public BankTransactionType BankTransactionTypeCurrent { get; set; }

        public Guid ExamTypeId { get; set; }
        [ForeignKey("ExamTypeId")]
        public ExamType ExamTypeCurrent { get; set; }

        public IEnumerable<Expression<Func<BankTransaction, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}

// https ://idpay.ir/web-service/v1.1/#972fadbc1d 
