using ExamContext.ReadModel.Queries.Contracts.SpeakingContext.SpeakingExamAggregate;
using ExamContext.ReadModel.Queries.Contracts.SpeakingContext.SpeakingExamAggregate.DataContracts;
using ExamContext.ReadModel.Queries.Contracts.SpeakingContext.SpeakingExamMeetingAggregate;
using ExamContext.ReadModel.Queries.Contracts.SpeakingContext.SpeakingExamMeetingAggregate.DataContracts;
using ExamContext.Speaking.Aplication.Contracts.SpeakingExamAggregate;
using ExamContext.Speaking.Aplication.Contracts.SpeakingExamMeetingAggregate;
using ExamContext.Speaking.Facade.Contracts.SpeakingExamAggregate;
using ExamContext.Speaking.Facade.Contracts.SpeakingExamMeetingAggregate;
using Framework.Mapper;
using Ielts.Common.GeneralClass;
using IeltsProject.AdminPresentation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IeltsProject.AdminPresentation.Controllers
{
    public class IeltsExamSpeakingController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ISpeakingExamQueryFacade iSpeakingExamQueryFacade;
        private readonly ISpeakingExamCommandFacade iSpeakingExamCommandFacade;
        private readonly ISpeakingExamMeetingQueryFacade iSpeakingExamMeetingQueryFacade;
        private readonly ISpeakingExamMeetingCommandFacade iSpeakingExamMeetingCommandFacade;
        public IeltsExamSpeakingController(UserManager<ApplicationUser> userManager,
                                   ISpeakingExamQueryFacade iSpeakingExamQueryFacade,
                                   ISpeakingExamCommandFacade iSpeakingExamCommandFacade,
                                   ISpeakingExamMeetingQueryFacade iSpeakingExamMeetingQueryFacade,
                                   ISpeakingExamMeetingCommandFacade iSpeakingExamMeetingCommandFacade)
        {
            this.userManager = userManager;
            this.iSpeakingExamQueryFacade = iSpeakingExamQueryFacade;
            this.iSpeakingExamCommandFacade = iSpeakingExamCommandFacade;
            this.iSpeakingExamMeetingQueryFacade = iSpeakingExamMeetingQueryFacade;
            this.iSpeakingExamMeetingCommandFacade = iSpeakingExamMeetingCommandFacade;

        }

        public IActionResult IeltsSpeaking_Load(Guid id)
        {
            var examCount = iSpeakingExamQueryFacade.GetSpeakingExamCount(id);
            if (examCount < 1)
            {
                ViewBag.IsEligibleToAddExam = true;
            }
            else
            {
                ViewBag.IsEligibleToAddExam = false;
            }
            ViewBag.IeltsExamId = id;
            return View();
        }
        public ActionResult IeltsSpeakingGridData(DataTableAjaxPostModel model, Guid id)
        {
            var SpeakingExamList = iSpeakingExamQueryFacade.GetSpeakingExamByFilteringList(ref model, id);

            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = SpeakingExamList
            });
        }
        public IActionResult AddIeltsSpeaking_Load(Guid id)
        {
            ViewBag.HasError = false;
            ViewBag.IeltsExamId = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddIeltsSpeaking(SpeakingExamQueryFacadeDto model)
        {
            try
            {
                var command = new AddSpeakingExamCommand();
                command.Title = model.Title;
                command.IeltsExamId = model.IeltsExamId;
                command.Description = model.Description;
                command.IsActive = true;
                command.IsDeleted = false;

                iSpeakingExamCommandFacade.AddSpeakingExam(command);

                return RedirectToAction("IeltsSpeaking_Load", new { Id = model.IeltsExamId });
            }
            catch (Exception e)
            {

                ModelState.AddModelError("AddIeltsSpeakingException", e.Message);
                ViewBag.HasError = true;
                ViewBag.IeltsExamId = model.IeltsExamId;
                return View("AddIeltsSpeaking_Load", model);
            }
            
        }
        public IActionResult EditSpeakingExam_Load(Guid id)
        {
            ViewBag.HasError = false;
            var SpeakingExam = iSpeakingExamQueryFacade.GetSpeakingExamById(id);
            return View(SpeakingExam);
        }
        [HttpPost]
        public IActionResult EditSpeakingExam(SpeakingExamQueryFacadeDto model)
        {
            try
            {
                var command = Mapper.Map<SpeakingExamQueryFacadeDto, UpdateSpeakingExamCommand>(model);
                iSpeakingExamCommandFacade.UpdateSpeakingExam(command);

                return RedirectToAction("IeltsSpeaking_Load", new { Id = model.IeltsExamId });
            }
            catch (Exception e)
            {
                ModelState.AddModelError("EditSpeakingExamException", e.Message);
                ViewBag.HasError = true;
                return View("EditSpeakingExam_Load", model);
            }
        }
        //-----------------------
        public IActionResult SpeakingMeeting_Load(Guid id)
        {
            ViewBag.SpeakingExamId = id;
            return View();
        }
        public ActionResult SpeakingMeetingListGridData(DataTableAjaxPostModel model, Guid id)
        {
            var SpeakingExamMeetingList = iSpeakingExamMeetingQueryFacade.GetSpeakingExamMeetingListForGridView(ref model, id);

            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = SpeakingExamMeetingList
            });
        }
        public IActionResult AddSpeakingMeeting_Load(Guid id)
        {
            ViewBag.HasError = false;
            ViewBag.SpeakingExamId = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddSpeakingMeeting(SpeakingExamMeetingQueryFacadeDto model)
        {
            try
            {
                var command = new AddSpeakingExamMeetingCommand();
                command.SpeakingExamId = model.SpeakingExamId;
                command.Title = model.Title;
                command.MeetingDate = DateConverter.ShamsiToMiladiConvert(model.MeetingDate_Persian);
                command.MeetingStartTime = model.MeetingStartTime;
                command.MeetingEndTime = model.MeetingEndTime;
                command.IsActive = true;

                iSpeakingExamMeetingCommandFacade.AddSpeakingExamMeeting(command);

                return RedirectToAction("SpeakingMeeting_Load", new { id = model.SpeakingExamId });
            }
            catch (Exception e)
            {
                ModelState.AddModelError("AddSpeakingMeetingException", e.Message);
                ViewBag.HasError = true;
                ViewBag.SpeakingExamId = model.SpeakingExamId;
                return View("AddSpeakingMeeting_Load", model);
            }
        }
        public IActionResult EditSpeakingExamMeeting_Load(Guid id, bool? hasError = false, string errorMessage = "")
        {
            ViewBag.HasError = hasError;
            ModelState.AddModelError("EditSpeakingExamMeetingException", errorMessage);
            var SpeakingExamMeeting = iSpeakingExamMeetingQueryFacade.GetSpeakingExamMeeting(id);
            SpeakingExamMeeting.MeetingDate_Persian = DateConverter.MiladiToShamsiConvert(SpeakingExamMeeting.MeetingDate);
            return View(SpeakingExamMeeting);
        }
        [HttpPost]
        public IActionResult EditSpeakingExamMeeting(SpeakingExamMeetingQueryFacadeDto model)
        {
            try
            {
                var command = Mapper.Map<SpeakingExamMeetingQueryFacadeDto, UpdateSpeakingExamMeetingCommand>(model);
                command.MeetingDate = DateConverter.ShamsiToMiladiConvert(model.MeetingDate_Persian);
                iSpeakingExamMeetingCommandFacade.UpdateSpeakingExamMeeting(command);

                return RedirectToAction("SpeakingMeeting_Load", new { id = model.SpeakingExamId });
            }
            catch (Exception e)
            {

                return RedirectToAction("EditSpeakingExamMeeting_Load", new { id = model.Id, hasError = true, errorMessage = e.Message });
            }
        }
        //-----------------------
    }
}
