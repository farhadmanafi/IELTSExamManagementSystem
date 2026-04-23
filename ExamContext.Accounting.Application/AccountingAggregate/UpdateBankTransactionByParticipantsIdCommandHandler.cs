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
    public class UpdateBankTransactionByParticipantsIdCommandHandler : ICommandHandler<UpdateBankTransactionByParticipantsIdCommand>
    {
        private readonly IBankTransactionRepository bankTransactionRepository;
        public UpdateBankTransactionByParticipantsIdCommandHandler(IBankTransactionRepository bankTransactionRepository)
        {
            this.bankTransactionRepository = bankTransactionRepository;
        }
        public void Execute(UpdateBankTransactionByParticipantsIdCommand command)
        {
            var bankTransaction = bankTransactionRepository.GetBankTransactionParticipantsId(command.ParticipantsId);
            bankTransaction.PaymentFinished = command.PaymentFinished;
            bankTransaction.BankTransactionCode = command.BankTransactionCode;
            bankTransaction.BankTransactionTypeId = command.BankTransactionTypeId;
            //Changest

            bankTransactionRepository.UpdateBankTransaction(bankTransaction);
        }
    }
}
