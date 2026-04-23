using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ParticipantsAggregate;
using Ielts.Common.GeneralClass;
using IeltsProject.Presentation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IeltsProject.Presentation.Controllers
{
    public class CustomerIeltsExamController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IIeltsExamParticipantsQueryFacade iIeltsExamParticipantsQueryFacade;
        private readonly IIeltsExamParticipantsDetailQueryFacade iIeltsExamParticipantsDetailQueryFacade;
        public CustomerIeltsExamController(IIeltsExamParticipantsQueryFacade iIeltsExamParticipantsQueryFacade,
            UserManager<ApplicationUser> userManager,
            IIeltsExamParticipantsDetailQueryFacade iIeltsExamParticipantsDetailQueryFacade)
        {
            this.iIeltsExamParticipantsQueryFacade = iIeltsExamParticipantsQueryFacade;
            this.userManager = userManager;
            this.iIeltsExamParticipantsDetailQueryFacade = iIeltsExamParticipantsDetailQueryFacade;
        }

        public ActionResult CustomerIeltsExamList() { 

            return View();
        }
        public ActionResult CustomerIeltsExamListGridData(DataTableAjaxPostModel model)
        {
            var customerId = new System.Guid(userManager.GetUserId(User));

            var ieltsExamResult = iIeltsExamParticipantsQueryFacade.GetIeltsExamFilteringListByCustomerId(ref model, customerId);
            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = ieltsExamResult
            });
        }
        public ActionResult IeltsExamParticipantDetail_Load(Guid id) { 
            var ieltsExamParticipantsDetailQueryFacade = iIeltsExamParticipantsDetailQueryFacade.GetIeltsExamParticipantsDetailByIeltsExamParticipantsId(id);
            
            return View(ieltsExamParticipantsDetailQueryFacade);
        }

    }
}
