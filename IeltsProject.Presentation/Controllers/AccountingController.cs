using ExamContext.ReadModel.Queries.Contracts.AccountingContext.AccountingAggregate;
using Ielts.Common.GeneralClass;
using IeltsProject.Presentation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IeltsProject.Presentation.Controllers
{
    public class AccountingController : Controller
    {
        private readonly IBankTransactionQueryFacade ibankTransactionQueryFacade;
        private readonly UserManager<ApplicationUser> userManager;
        public AccountingController(IBankTransactionQueryFacade ibankTransactionQueryFacade,
             UserManager<ApplicationUser> userManager)
        {
            this.ibankTransactionQueryFacade = ibankTransactionQueryFacade;
            this.userManager = userManager;
        }
        public IActionResult ShowPaymentList()
        {
            return View();
        }
        public ActionResult GetPaymentListData(DataTableAjaxPostModel model)
        {
            var customerId = new System.Guid(userManager.GetUserId(User));
            var paymentList = ibankTransactionQueryFacade.GetBankTransactionListForGivenCustomer(ref model,customerId);

            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = paymentList
            });
        }
    }
}
