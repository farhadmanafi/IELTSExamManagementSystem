using ExamContext.Ielts.Aplication.Contracts.ResualtAggregarte;
using ExamContext.Ielts.Facade.Contracts.ResualtAggregarte;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ParticipantsAggregate;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ResualtAggregarte;
using ExamContext.ReadModel.Queries.Contracts.WritingContext.WritingExamAggregate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IeltsProject.Presentation.Controllers
{
    public class IeltsExamWritingResultController : Controller
    {
        private readonly IWritingExamSectionQueryFacade iwritingExamSectionQueryFacade;
        private readonly IUserResualtFacade iuserResaultCommandFacade;
        private readonly IUserResualtQueryFacade iuserResualtQueryFacade;
        private readonly IWritingExamQueryFacade iwritingExamQueryFacade;
        private readonly IIeltsExamParticipantsQueryFacade iieltsExamParticipantsQueryFacade;
        public IeltsExamWritingResultController(IWritingExamSectionQueryFacade iwritingExamSectionQueryFacade,
                                                IUserResualtFacade iuserResaultCommandFacade,
                                                IUserResualtQueryFacade iuserResualtQueryFacade,
                                                IWritingExamQueryFacade iwritingExamQueryFacade,
                                                IIeltsExamParticipantsQueryFacade iieltsExamParticipantsQueryFacade)
        {
            this.iwritingExamSectionQueryFacade = iwritingExamSectionQueryFacade;
            this.iuserResaultCommandFacade = iuserResaultCommandFacade;
            this.iuserResualtQueryFacade = iuserResualtQueryFacade;
            this.iwritingExamQueryFacade = iwritingExamQueryFacade;
            this.iieltsExamParticipantsQueryFacade = iieltsExamParticipantsQueryFacade;
        }
        public IActionResult IeltsExamWritingResult_Load(Guid ieltsExamParticipantsId, Guid writingExamId)
        {
            try
            {
                var ieltsExamId = iwritingExamQueryFacade.GetIeltsExamByWritingExamId(writingExamId);
                var customerId = iieltsExamParticipantsQueryFacade.GetCustomerIdFromParticipantId(ieltsExamParticipantsId);
                var result = iwritingExamSectionQueryFacade.GetWrtingExamUserAnswersPerSectionByExamId(ieltsExamId, customerId);
                var examScore = iuserResualtQueryFacade.GetUserExamResult(ieltsExamParticipantsId, customerId);
                ViewBag.WritingScore = examScore.WritingScore == null ? "Not Register" : examScore.WritingScore?.ToString();
                ViewBag.ParticipantId = ieltsExamParticipantsId;
                ViewBag.CustomerId = customerId;
                //ViewBag.IeltsExamId = ieltsExamId;
                ViewBag.WritingExamId = writingExamId;

                return View(result);
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
    }
}
