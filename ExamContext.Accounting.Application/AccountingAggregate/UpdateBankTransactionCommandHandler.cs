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
    public class UpdateBankTransactionCommandHandler : ICommandHandler<UpdateBankTransactionCommand>
    {
        private readonly IBankTransactionRepository bankTransactionRepository;
        public UpdateBankTransactionCommandHandler(IBankTransactionRepository bankTransactionRepository)
        {
            this.bankTransactionRepository = bankTransactionRepository;
        }
        public void Execute(UpdateBankTransactionCommand command)
        {
            var bankTransaction = bankTransactionRepository.GetBankTransaction(command.Id);
            bankTransaction.PaymentFinished = command.PaymentFinished;
            //Changest

            bankTransactionRepository.UpdateBankTransaction(bankTransaction);
        }
    }
}
