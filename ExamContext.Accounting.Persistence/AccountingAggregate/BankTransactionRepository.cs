using ExamContext.Accounting.Domain.AccountingAggregate;
using ExamContext.Accounting.Domain.AccountingAggregate.Services;
using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Accounting.Persistence.AccountingAggregate
{
    public class BankTransactionRepository : RepositoryBase<BankTransaction>, IBankTransactionRepository
    {
        public BankTransactionRepository(IDbContext context) : base(context)
        {

        }

        public void AddBankTransaction(BankTransaction bankTransaction)
        {
            Set.Add(bankTransaction);
        }

        public BankTransaction GetBankTransaction(Guid id)
        {
            return Set.SingleOrDefault(a => a.Id == id);
        }

        public BankTransaction GetBankTransactionParticipantsId(Guid participantsId)
        {
            return Set.SingleOrDefault(a => a.ParticipantsId == participantsId);
        }

        public void UpdateBankTransaction(BankTransaction bankTransaction)
        {
            Set.Update(bankTransaction);
        }
    }
}
