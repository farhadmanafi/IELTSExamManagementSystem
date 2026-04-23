using ExamContext.Ielts.Aplication.Contracts.ResualtAggregarte;
using ExamContext.Ielts.Facade.Contracts.ResualtAggregarte;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ParticipantsAggregate;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ResualtAggregarte;
using ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningExamAggregate;
using ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningUserAnswerAggregate;
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
    public class IeltsExamListeningResultController : Controller
    {
        private readonly IListeningUserAnswerQueryFacade ilisteningUserAnswerQueryFacade;
        private readonly IUserResualtFacade iuserResaultCommandFacade;
        private readonly IUserResualtQueryFacade iuserResualtQueryFacade;
        private readonly IListeningExamQueryFacade ilisteningExamQueryFacade;
        private readonly IIeltsExamParticipantsQueryFacade iieltsExamParticipantsQueryFacade;
        private readonly UserManager<ApplicationUser> userManager;
        public IeltsExamListeningResultController(IListeningUserAnswerQueryFacade ilisteningUserAnswerQueryFacade,
                                                  IUserResualtFacade iuserResaultCommandFacade,
                                                  IUserResualtQueryFacade iuserResualtQueryFacade,
                                                  IListeningExamQueryFacade ilisteningExamQueryFacade,
                                                  IIeltsExamParticipantsQueryFacade iieltsExamParticipantsQueryFacade,
                                                  UserManager<ApplicationUser> userManager)
        {
            this.ilisteningUserAnswerQueryFacade = ilisteningUserAnswerQueryFacade;
            this.iuserResaultCommandFacade = iuserResaultCommandFacade;
            this.iuserResualtQueryFacade = iuserResualtQueryFacade;
            this.ilisteningExamQueryFacade = ilisteningExamQueryFacade;
            this.iieltsExamParticipantsQueryFacade = iieltsExamParticipantsQueryFacade;
            this.userManager = userManager;
        }
        public IActionResult IeltsExamListeningResult_Load(Guid ieltsExamParticipantsId, Guid listeningExamId)
        {
            try
            {
                var customerId = new System.Guid(userManager.GetUserId(User));
                //var ieltsExamId = ilisteningExamQueryFacade.GetIeltsExamByListeningExamId(examId);
                //var customerId = iieltsExamParticipantsQueryFacade.GetCustomerIdFromParticipantId(ieltsExamParticipantsId);
                var examScore = iuserResualtQueryFacade.GetUserExamResult(ieltsExamParticipantsId, customerId);
                ViewBag.ListeningScore = examScore.ListeningScore == null ? "Not Register" : examScore.ListeningScore?.ToString();
                ViewBag.IeltsExamParticipantsId = ieltsExamParticipantsId;
                //ViewBag.CustomerId = customerId;
                ViewBag.ListeningExamId = listeningExamId;

                return View();
            }
            catch (Exception)
            {

                return RedirectToAction("ShowResultStatus", new { CompletionFlag = false, id = ieltsExamParticipantsId });
            }
        }
        public ActionResult ShowResultStatus(bool CompletionFlag, Guid? id)
        {
            ViewBag.CompletionStatus = CompletionFlag;
            ViewBag.ParticipantId = id;
            return View();
        }
        public ActionResult IeltsExamListeningUserScoreDetailData(DataTableAjaxPostModel model, Guid listeningExamId, Guid ieltsExamParticipantsId)
        {
            var customerId = new System.Guid(userManager.GetUserId(User));

            var ListeningUserScoreList = ilisteningUserAnswerQueryFacade.GetListeningExamUserAnswerListUserPanel(ref model, listeningExamId, ieltsExamParticipantsId, customerId);

            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = ListeningUserScoreList
            });
        }
    }
}
