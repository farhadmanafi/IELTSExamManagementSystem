using ExamContext.Ielts.Aplication.Contracts.ResualtAggregarte;
using ExamContext.Ielts.Facade.Contracts.ResualtAggregarte;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ParticipantsAggregate;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ResualtAggregarte;
using ExamContext.ReadModel.Queries.Contracts.SpeakingContext.SpeakingExamAggregate;
using ExamContext.ReadModel.Queries.Contracts.SpeakingContext.SpeakingExamMeetingAggregate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IeltsProject.Presentation.Controllers
{
    public class IeltsExamSpeakingResultController : Controller
    {
        private readonly IUserResualtFacade iuserResaultCommandFacade;
        private readonly IUserResualtQueryFacade iuserResualtQueryFacade;
        private readonly ISpeakingExamQueryFacade ispeakingExamQueryFacade;
        private readonly IIeltsExamParticipantsQueryFacade iieltsExamParticipantsQueryFacade;
        private readonly ISpeakingExamMeetingReserveQueryFacade iSpeakingExamMeetingReserveQueryFacade;
        public IeltsExamSpeakingResultController(IUserResualtFacade iuserResaultCommandFacade,
                                                 IUserResualtQueryFacade iuserResualtQueryFacade,
                                                 ISpeakingExamQueryFacade ispeakingExamQueryFacade,
                                                  IIeltsExamParticipantsQueryFacade iieltsExamParticipantsQueryFacade,
                                                  ISpeakingExamMeetingReserveQueryFacade iSpeakingExamMeetingReserveQueryFacade)
        {
            this.iuserResaultCommandFacade = iuserResaultCommandFacade;
            this.iuserResualtQueryFacade = iuserResualtQueryFacade;
            this.ispeakingExamQueryFacade = ispeakingExamQueryFacade;
            this.iieltsExamParticipantsQueryFacade = iieltsExamParticipantsQueryFacade;
            this.iSpeakingExamMeetingReserveQueryFacade = iSpeakingExamMeetingReserveQueryFacade; 
        }
        public IActionResult IeltsExamSpeakingResult_Load(Guid ieltsExamParticipantsId, Guid speakingExamId)
        {
            try
            {
                var speakingExamMeeting = iSpeakingExamMeetingReserveQueryFacade.GetSpeakingExamMeetingReserveByIeltsExamParticipantId(ieltsExamParticipantsId);

                //var ieltsExamId = ispeakingExamQueryFacade.GetIeltsExamBySpeakingExamId(examId);
                var customerId = iieltsExamParticipantsQueryFacade.GetCustomerIdFromParticipantId(ieltsExamParticipantsId);
                var examScore = iuserResualtQueryFacade.GetUserExamResult(ieltsExamParticipantsId, customerId);
                ViewBag.SpeakingScore = examScore.SpeakingScore == null ? "Not Register" : examScore.SpeakingScore?.ToString();
                ViewBag.ParticipantId = ieltsExamParticipantsId;
                ViewBag.CustomerId = customerId;
                //ViewBag.IeltsExamId = ieltsExamId;
                ViewBag.SpeakingExamId = speakingExamId;

                return View(speakingExamMeeting);
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
