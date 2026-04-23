using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.IeltsAggregarte.IeltsAggregarte;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ParticipantsAggregate;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ResualtAggregarte;
using Ielts.Common.GeneralClass;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IeltsProject.AdminPresentation.Controllers
{
    [Authorize(Roles = "Admin")]
    public class IeltsExamResultController : Controller
    {
        private readonly IIeltsExamQueryFacade iieltsExamQueryFacade;
        private readonly IIeltsExamParticipantsQueryFacade iIeltsExamParticipantsQueryFacade;
        private readonly IUserResualtQueryFacade iuserResualtQueryFacade;
        public IeltsExamResultController(IIeltsExamQueryFacade iieltsExamQueryFacade,
                                         IIeltsExamParticipantsQueryFacade iIeltsExamParticipantsQueryFacade,
                                         IUserResualtQueryFacade iuserResualtQueryFacade)
        {
            this.iieltsExamQueryFacade = iieltsExamQueryFacade;
            this.iIeltsExamParticipantsQueryFacade = iIeltsExamParticipantsQueryFacade;
            this.iuserResualtQueryFacade = iuserResualtQueryFacade;

        }
        public IActionResult ExamResultList()
        {
            return View();
        }
        public ActionResult ExamResultListData(DataTableAjaxPostModel model)
        {
            var ieltsExamResultList = iieltsExamQueryFacade.GetIeltsExamResulFilteringList(ref model);
            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = ieltsExamResultList
            });
        }
        public IActionResult IeltsExamParticipants_Load(Guid id)
        {
            ViewBag.IeltsExamId = id;
            return View();
        }
        public ActionResult IeltsExamParticipantsData(DataTableAjaxPostModel model,Guid id)
        {
            var ieltsExamResult = iIeltsExamParticipantsQueryFacade.GetIeltsExamFilteringList(ref model,id);
            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = ieltsExamResult
            });
        }
        public IActionResult IeltsExamParticipantResult_Load(Guid customerId, Guid ieltsExamParticipantsId)
        {
            ViewBag.CustomerId = customerId;
            ViewBag.IeltsExamParticipantsId = ieltsExamParticipantsId;
            return View();
        }
        //TODO
        public ActionResult IeltsExamParticipantResultData(DataTableAjaxPostModel model, Guid customerId, Guid ieltsExamParticipantsId)
        {
            var ieltsExamResult = iuserResualtQueryFacade.GetUserExamResultFilteringList(ref model,customerId, ieltsExamParticipantsId);
            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = ieltsExamResult
            });
        }
    }
}
