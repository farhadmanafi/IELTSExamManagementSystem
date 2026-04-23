using ExamContext.Accounting.Aplication.Contracts.AccountingAggregate;
using ExamContext.Accounting.Domain.AccountingAggregate.Services;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Accounting.Aplication.AccountingAggregate
{
    public class DeleteBankTransactionCommandHandler : ICommandHandler<DeleteBankTransactionCommand>
    {
        private readonly IBankTransactionRepository bankTransactionRepository;
        public DeleteBankTransactionCommandHandler(IBankTransactionRepository bankTransactionRepository)
        {
            this.bankTransactionRepository = bankTransactionRepository;
        }
        public void Execute(DeleteBankTransactionCommand command)
        {
            var bankTransaction = bankTransactionRepository.GetBankTransaction(command.Id);
            bankTransaction.IsDeleted = true;
            bankTransaction.IsActive = false;

            bankTransactionRepository.UpdateBankTransaction(bankTransaction);
        }
    }
}
