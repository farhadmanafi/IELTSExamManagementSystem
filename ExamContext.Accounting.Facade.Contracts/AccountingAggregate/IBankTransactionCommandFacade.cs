using ExamContext.Accounting.Aplication.Contracts.AccountingAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Accounting.Facade.Contracts.AccountingAggregate
{
    public interface IBankTransactionCommandFacade
    {
        void AddBankTransaction(AddBankTransactionCommand command);
        void UpdateBankTransaction(UpdateBankTransactionCommand command);
        void DeleteBankTransaction(DeleteBankTransactionCommand command);
        void UpdateBankTransactionByParticipantsId(UpdateBankTransactionByParticipantsIdCommand command);
    }
}
