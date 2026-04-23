using ExamContext.Ielts.Aplication.Contracts.ResualtAggregarte;
using ExamContext.Ielts.Facade.Contracts.ResualtAggregarte;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ResualtAggregarte;
using ExamContext.ReadModel.Queries.Contracts.SpeakingContext.SpeakingExamMeetingAggregate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IeltsProject.AdminPresentation.Controllers
{
    public class IeltsExamSpeakingResultController : Controller
    {
        private readonly IUserResualtFacade iuserResaultCommandFacade;
        private readonly IUserResualtQueryFacade iuserResualtQueryFacade;
        private readonly ISpeakingExamMeetingReserveQueryFacade iSpeakingExamMeetingReserveQueryFacade;
        public IeltsExamSpeakingResultController(IUserResualtFacade iuserResaultCommandFacade,
                                                 IUserResualtQueryFacade iuserResualtQueryFacade,
                                                 ISpeakingExamMeetingReserveQueryFacade iSpeakingExamMeetingReserveQueryFacade)
        {
            this.iuserResaultCommandFacade = iuserResaultCommandFacade;
            this.iuserResualtQueryFacade = iuserResualtQueryFacade;
            this.iSpeakingExamMeetingReserveQueryFacade = iSpeakingExamMeetingReserveQueryFacade;
        }
        public IActionResult IeltsExamSpeakingResult_Load(Guid customerId, Guid ieltsExamParticipantsId)
        {
            var examScore = iuserResualtQueryFacade.GetUserExamResult(ieltsExamParticipantsId, customerId);
            var speakingExamMeeting = iSpeakingExamMeetingReserveQueryFacade.GetSpeakingExamMeetingReserveByIeltsExamParticipantId(ieltsExamParticipantsId);
            if (examScore.SpeakingScore != null)
            {
                ViewBag.HasSpeakingScore = true;
                ViewBag.SpeakingScore = examScore.SpeakingScore;
            }
            else
            {
                ViewBag.HasSpeakingScore = false;
                ViewBag.Scores = new List<SelectListItem>{ new SelectListItem { Value="0",Text="0"},
                                                     new SelectListItem { Value="0.5",Text="0.5"},
                                                     new SelectListItem { Value="1",Text="1"},
                                                     new SelectListItem { Value="1.5",Text="1.5"},
                                                     new SelectListItem { Value="2",Text="2"},
                                                     new SelectListItem { Value="2.5",Text="2.5"},
                                                     new SelectListItem { Value="3",Text="3"},
                                                     new SelectListItem { Value="3.5",Text="3.5"},
                                                     new SelectListItem { Value="4",Text="4"},
                                                     new SelectListItem { Value="4.5",Text="4.5"},
                                                     new SelectListItem { Value="5",Text="5"},
                                                     new SelectListItem { Value="5.5",Text="5.5"},
                                                     new SelectListItem { Value="6",Text="6"},
                                                     new SelectListItem { Value="6.5",Text="6.5"},
                                                     new SelectListItem { Value="7",Text="7"},
                                                     new SelectListItem { Value="7.5",Text="7.5"},
                                                     new SelectListItem { Value="8",Text="8"},
                                                     new SelectListItem { Value="8.5",Text="8.5"},
                                                     new SelectListItem { Value="9",Text="9"}};
            }
            ViewBag.CustomerId = customerId;
            ViewBag.IeltsExamParticipantsId = ieltsExamParticipantsId;
            return View(speakingExamMeeting);
        }
        [HttpPost]
        public IActionResult AddScore(float speakingExamScore, Guid customerId, Guid ieltsExamParticipantsId)
        {
            var command = new UpdateSpeakingScoreCommand();
            command.IeltsExamParticipantsId = ieltsExamParticipantsId;
            command.CustomerId = customerId;
            command.SpeakingScore = speakingExamScore;
            iuserResaultCommandFacade.UpdateSpeakingScore(command);
            return RedirectToAction("IeltsExamParticipantResult_Load", "IeltsExamResult", new { customerId = customerId, ieltsExamParticipantsId = ieltsExamParticipantsId });
        }
    }
}
