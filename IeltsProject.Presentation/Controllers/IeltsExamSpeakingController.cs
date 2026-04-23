using ExamContext.Ielts.Aplication.Contracts.ParticipantsAggregate;
using ExamContext.Ielts.Facade.Contracts.ParticipantsAggregate;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ParticipantsAggregate;
using ExamContext.ReadModel.Queries.Contracts.SpeakingContext.SpeakingExamAggregate;
using ExamContext.ReadModel.Queries.Contracts.SpeakingContext.SpeakingExamMeetingAggregate;
using ExamContext.Speaking.Aplication.Contracts.SpeakingExamMeetingAggregate;
using ExamContext.Speaking.Facade.Contracts.SpeakingExamMeetingAggregate;
using IeltsProject.Presentation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace IeltsProject.Presentation.Controllers
{
    public class IeltsExamSpeakingController : Controller
    {
        private readonly ISpeakingExamQueryFacade iSpeakingExamQueryFacade;
        private readonly ISpeakingExamMeetingQueryFacade iSpeakingExamMeetingQueryFacade;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ISpeakingExamMeetingReserveCommandFacade iSpeakingExamMeetingReserveCommandFacade;
        private readonly IIeltsExamParticipantsDetailFacade iIeltsExamParticipantsDetailFacade;
        private readonly IIeltsExamParticipantsDetailQueryFacade iIeltsExamParticipantsDetailQueryFacade;
        public IeltsExamSpeakingController(ISpeakingExamQueryFacade iSpeakingExamQueryFacade,
            ISpeakingExamMeetingQueryFacade iSpeakingExamMeetingQueryFacade,
            UserManager<ApplicationUser> userManager,
            ISpeakingExamMeetingReserveCommandFacade iSpeakingExamMeetingReserveCommandFacade,
            IIeltsExamParticipantsDetailFacade iIeltsExamParticipantsDetailFacade,
            IIeltsExamParticipantsDetailQueryFacade iIeltsExamParticipantsDetailQueryFacade)
        {
            this.iSpeakingExamQueryFacade = iSpeakingExamQueryFacade;
            this.iSpeakingExamMeetingQueryFacade = iSpeakingExamMeetingQueryFacade;
            this.userManager = userManager;
            this.iSpeakingExamMeetingReserveCommandFacade = iSpeakingExamMeetingReserveCommandFacade;
            this.iIeltsExamParticipantsDetailFacade = iIeltsExamParticipantsDetailFacade;
            this.iIeltsExamParticipantsDetailQueryFacade = iIeltsExamParticipantsDetailQueryFacade;
        }

        public IActionResult IeltsExamSpeakingPage(Guid id, Guid pdId)
        {
            try
            {
                //------
                UpdateIeltsExamParticipantsDetailCommand updateIeltsExamParticipantsDetailCommand = new UpdateIeltsExamParticipantsDetailCommand();
                updateIeltsExamParticipantsDetailCommand.Id = pdId;
                updateIeltsExamParticipantsDetailCommand.SpeakingExamIsSetSession = true;

                iIeltsExamParticipantsDetailFacade.UpdateIeltsExamParticipantsDetail(updateIeltsExamParticipantsDetailCommand);
                //------
                var writingExam = iSpeakingExamQueryFacade.GetSpeakingExamForUserPanel(id);

                ViewBag.IeltsExamId = writingExam.IeltsExamId;

                var speakingExamSectionList = iSpeakingExamMeetingQueryFacade.GetSpeakingExamMeetingListForUserPanel(writingExam.Id);
                ViewBag.SpeakingExamSectionList = new SelectList(speakingExamSectionList, "Id", "Title");

                var ieltsExamParticipantsDetail = iIeltsExamParticipantsDetailQueryFacade.GetIeltsExamParticipantsDetailById(pdId);

                IeltsSpeakingQuestionAnswereViewModel model = new IeltsSpeakingQuestionAnswereViewModel();
                model.IeltsExamId = writingExam.IeltsExamId;
                model.IeltsSpeakingId = writingExam.Id;
                model.IeltsExamParticipantId = ieltsExamParticipantsDetail.IeltsExamParticipantsId;
                ViewBag.HasError = false;
                return View(model);
            }
            catch (Exception)
            {
                ModelState.AddModelError("IeltsExamSpeakingPageException", "There is a Problem. Please contact the support team");
                ViewBag.HasError = true;
                return View();
            }
        }

        [HttpPost]
        public ActionResult IeltsExamSpeakingPage(IeltsSpeakingQuestionAnswereViewModel model)
        {
            try
            {
                var customerId = new System.Guid(userManager.GetUserId(User));

                AddSpeakingExamMeetingReserveCommand addSpeakingExamMeetingReserveCommand = new AddSpeakingExamMeetingReserveCommand();
                addSpeakingExamMeetingReserveCommand.CustomerId = customerId;
                addSpeakingExamMeetingReserveCommand.SpeakingExamMeetingId = model.MeetingId;
                addSpeakingExamMeetingReserveCommand.IeltsExamParticipantId = model.IeltsExamParticipantId;
                addSpeakingExamMeetingReserveCommand.IsActive = true;
                addSpeakingExamMeetingReserveCommand.IsDeleted = false;

                iSpeakingExamMeetingReserveCommandFacade.AddSpeakingExamMeetingReserve(addSpeakingExamMeetingReserveCommand);

                return RedirectToAction("SpeakingExamCompleted", new { speakingExamCompleted = true });
            }
            catch (Exception)
            {

                return RedirectToAction("SpeakingExamCompleted", new { speakingExamCompleted = false });
            }
        }
        public ActionResult SpeakingExamCompleted(bool speakingExamCompleted)
        {
            ViewBag.CompletionStatus = speakingExamCompleted;
            return View();
        }

    }
}
