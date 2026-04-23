using ExamContext.Ielts.Aplication.Contracts.ResualtAggregarte;
using ExamContext.Ielts.Facade.Contracts.ResualtAggregarte;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ParticipantsAggregate;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ResualtAggregarte;
using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingExamAggregate;
using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingUserAnswerAggregate;
using Ielts.Common.GeneralClass;
using IeltsProject.Presentation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IeltsProject.Presentation.Controllers
{
    public class IeltsExamReadingResultController : Controller
    {
        private readonly IReadingUserAnswerQueryFacade iReadingUserAnswerQueryFacade;
        private readonly IUserResualtFacade iuserResaultCommandFacade;
        private readonly IUserResualtQueryFacade iuserResualtQueryFacade;
        private readonly IReadingExamQueryFacade iReadingExamQueryFacade;
        private readonly IIeltsExamParticipantsQueryFacade iieltsExamParticipantsQueryFacade;
        private readonly UserManager<ApplicationUser> userManager;
        public IeltsExamReadingResultController(IReadingUserAnswerQueryFacade iReadingUserAnswerQueryFacade,
                                                IUserResualtFacade iuserResaultCommandFacade,
                                                IUserResualtQueryFacade iuserResualtQueryFacade,
                                                IReadingExamQueryFacade iReadingExamQueryFacade,
                                                IIeltsExamParticipantsQueryFacade iieltsExamParticipantsQueryFacade,
                                                UserManager<ApplicationUser> userManager)
        {
            this.iReadingUserAnswerQueryFacade = iReadingUserAnswerQueryFacade;
            this.iuserResaultCommandFacade = iuserResaultCommandFacade;
            this.iuserResualtQueryFacade = iuserResualtQueryFacade;
            this.iReadingExamQueryFacade = iReadingExamQueryFacade;
            this.iieltsExamParticipantsQueryFacade = iieltsExamParticipantsQueryFacade;
            this.userManager = userManager;
        }
        public IActionResult IeltsExamReadingResult_Load(Guid ieltsExamParticipantsId, Guid readingExamId)
        {
            try
            {
                //var ieltsExamId = iReadingExamQueryFacade.GetIeltsExamByReadingExamId(examId);
                var customerId = iieltsExamParticipantsQueryFacade.GetCustomerIdFromParticipantId(ieltsExamParticipantsId);
                var examScore = iuserResualtQueryFacade.GetUserExamResult(ieltsExamParticipantsId, customerId);
                ViewBag.ReadingScore = examScore.ReadingScore == null ? "Not Register" : examScore.ReadingScore?.ToString();
                ViewBag.IeltsExamParticipantsId = ieltsExamParticipantsId;
                ViewBag.CustomerId = customerId;
                //ViewBag.IeltsExamId = ieltsExamId;
                ViewBag.ReadingExamId = readingExamId;

                return View();
            }
            catch (Exception)
            {

                return RedirectToAction("ShowResultStatus", new { CompletionFlag = false,id= ieltsExamParticipantsId });
            }
        }
        public ActionResult ShowResultStatus(bool CompletionFlag, Guid? id)
        {
            ViewBag.CompletionStatus = CompletionFlag;
            ViewBag.ParticipantId = id;
            return View();
        }
        public ActionResult IeltsExamReadingUserScoreDetailData(DataTableAjaxPostModel model, Guid readingExamId, Guid ieltsExamParticipantsId)
        {
            var customerId = new System.Guid(userManager.GetUserId(User));
            var readingUserScoreList = iReadingUserAnswerQueryFacade.GetReadingExamUserAnswerListUserPanel(ref model, readingExamId, ieltsExamParticipantsId, customerId);

            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = readingUserScoreList
            });
        }
    }
}
