using ExamContext.Accounting.Aplication.Contracts.AccountingAggregate;
using ExamContext.Accounting.Facade.Contracts.AccountingAggregate;
using Framework.Core.Application;
using Framework.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Accounting.Facade.AccountingAggregate
{
    public class BankTransactionCommandFacade : FacadeCommandBase, IBankTransactionCommandFacade
    {
        public BankTransactionCommandFacade(ICommandBus commandBus) : base(commandBus)
        {

        }

        public void AddBankTransaction(AddBankTransactionCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeleteBankTransaction(DeleteBankTransactionCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateBankTransaction(UpdateBankTransactionCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateBankTransactionByParticipantsId(UpdateBankTransactionByParticipantsIdCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
