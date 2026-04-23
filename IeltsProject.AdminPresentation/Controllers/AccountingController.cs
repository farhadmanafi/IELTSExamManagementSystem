using ExamContext.ReadModel.Queries.Contracts.AccountingContext.AccountingAggregate;
using Ielts.Common.GeneralClass;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IeltsProject.AdminPresentation.Controllers
{
    public class AccountingController : Controller
    {
        private readonly IBankTransactionQueryFacade ibankTransactionQueryFacade;
        public AccountingController(IBankTransactionQueryFacade ibankTransactionQueryFacade)
        {
            this.ibankTransactionQueryFacade = ibankTransactionQueryFacade;
        }
        public IActionResult ShowPaymentList()
        {
            return View();
        }
        public ActionResult GetPaymentListData(DataTableAjaxPostModel model)
        {
            var paymentList = ibankTransactionQueryFacade.GetBankTransactionList(ref model);

            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = paymentList
            });
        }
    }
}
