using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.AccountingContext.AccountingAggregate.DataContracts
{
    public class BankTransactionListQueryFacadeDto
    {
        public Guid IeltsExamParticipantsId { get; set; }
        public Guid BankTransactionTypeId { get; set; }
        public string BankTransactionTitle { get; set; }
        public Guid ExamTypeId { get; set; }
        public string ExamTypeTitle { get; set; }
        public long? CalculatedPriceAmount { get; set; }
        public long PriceAmount { get; set; }
        public int? DiscontentAmount { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public Guid IeltsExamId { get; set; }
        public string IeltsExamTitle { get; set; }
        public Guid IeltsExamPriceId { get; set; }
        public DateTime? PaymentDateTime { get; set; }
        public string PaymentDateTimePersian { get; set; }
        public string BankTransactionCode { get; set; }


    }
}
