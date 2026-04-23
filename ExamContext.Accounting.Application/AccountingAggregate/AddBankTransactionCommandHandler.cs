using ExamContext.Accounting.Aplication.Contracts.AccountingAggregate;
using ExamContext.Accounting.Domain.AccountingAggregate;
using ExamContext.Accounting.Domain.AccountingAggregate.Services;
using ExamContext.Accounting.Domain.Contracts.AccountingAggregate;
using Framework.Application;
using Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Accounting.Aplication.AccountingAggregate
{
    public class AddBankTransactionCommandHandler : ICommandHandler<AddBankTransactionCommand>
    {
        private readonly IBankTransactionRepository bankTransactionRepository;
        public AddBankTransactionCommandHandler(IBankTransactionRepository bankTransactionRepository)
        {
            this.bankTransactionRepository = bankTransactionRepository;
        }
        public void Execute(AddBankTransactionCommand command)
        {
            var bankTransactionDto = Mapper.Map<AddBankTransactionCommand, BankTransactionDto>(command);
            var bankTransaction = new BankTransaction(bankTransactionDto);

            bankTransactionRepository.AddBankTransaction(bankTransaction);
        }
    }
}
