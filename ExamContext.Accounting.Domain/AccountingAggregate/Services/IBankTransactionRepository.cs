using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Accounting.Domain.AccountingAggregate.Services
{
    public interface IBankTransactionRepository
    {
        void AddBankTransaction(BankTransaction bankTransaction);
        BankTransaction GetBankTransaction(Guid id);
        BankTransaction GetBankTransactionParticipantsId(Guid participantsId);
        void UpdateBankTransaction(BankTransaction bankTransaction);
    }
}
