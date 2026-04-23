using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Accounting.Aplication.Contracts.AccountingAggregate
{
    public class DeleteBankTransactionCommand:Command
    {
        public Guid Id { get; set; }
        public Guid ParticipantsId { get; set; }
        public Guid BankTransactionTypeId { get; set; }
    }
}
