using ExamContext.ReadModel.Queries.Contracts.AccountingContext.AccountingAggregate.DataContracts;
using Framework.Facade;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.AccountingContext.AccountingAggregate
{
    public interface IBankTransactionQueryFacade:IQueryFacade
    {
        IList<BankTransactionListQueryFacadeDto> GetBankTransactionList(ref DataTableAjaxPostModel filters);
        IList<BankTransactionListQueryFacadeDto> GetBankTransactionListForGivenCustomer(ref DataTableAjaxPostModel filters,Guid customerId);
        BankTransactionListQueryFacadeDto GetBankTransactionByPaymentId(Guid paymentId);
    }
}
