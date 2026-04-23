using ExamContext.Ielts.Aplication.Contracts.ParticipantsAggregate;
using ExamContext.Ielts.Facade.Contracts.ParticipantsAggregate;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ParticipantsAggregate;
using ExamContext.ReadModel.Queries.Contracts.WritingContext.WritingExamAggregate;
using ExamContext.Writing.Aplication.Contracts.WritingUserAnswerAggregate;
using ExamContext.Writing.Facade.Contracts.WritingUserAnswerAggregate;
using IeltsProject.Presentation.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IeltsProject.Presentation.Controllers
{
    public class IeltsExamWritingController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWritingExamQueryFacade iWritingExamQueryFacade;
        private readonly IWritingUserAnswerCommandFacade iWritingUserAnswerCommandFacade;
        private readonly IWritingExamSectionQueryFacade iwritingExamSectionQueryFacade;
        private readonly IIeltsExamParticipantsDetailFacade iIeltsExamParticipantsDetailFacade;
        private readonly IIeltsExamParticipantsDetailQueryFacade iIeltsExamParticipantsDetailQueryFacade;
        private readonly IWebHostEnvironment root;
        public IeltsExamWritingController(IWritingExamQueryFacade iWritingExamQueryFacade,
            IWritingUserAnswerCommandFacade iWritingUserAnswerCommandFacade,
            IWritingExamSectionQueryFacade iwritingExamSectionQueryFacade,
            IIeltsExamParticipantsDetailFacade iIeltsExamParticipantsDetailFacade,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment root,
            IIeltsExamParticipantsDetailQueryFacade iIeltsExamParticipantsDetailQueryFacade)
        {
            this.iWritingExamQueryFacade = iWritingExamQueryFacade;
            this.iWritingUserAnswerCommandFacade = iWritingUserAnswerCommandFacade;
            this.iwritingExamSectionQueryFacade = iwritingExamSectionQueryFacade;
            this.iIeltsExamParticipantsDetailFacade = iIeltsExamParticipantsDetailFacade;
            this.root = root;
            this.userManager = userManager;
            this.iIeltsExamParticipantsDetailQueryFacade = iIeltsExamParticipantsDetailQueryFacade;

        }

        public IActionResult IeltsExamWritingPage(Guid id, Guid pdId)
        {
            try
            {
                //------
                UpdateIeltsExamParticipantsDetailCommand updateIeltsExamParticipantsDetailCommand = new UpdateIeltsExamParticipantsDetailCommand();
                updateIeltsExamParticipantsDetailCommand.Id = pdId;
                updateIeltsExamParticipantsDetailCommand.WritingExamIsGive = true;
                updateIeltsExamParticipantsDetailCommand.WritingExamStartDateTime = DateTime.Now;

                iIeltsExamParticipantsDetailFacade.UpdateIeltsExamParticipantsDetail(updateIeltsExamParticipantsDetailCommand);
                //------

                var writingExam = iWritingExamQueryFacade.GetWritingExamForUserPanel(id);

                ViewBag.IeltsExamId = writingExam.IeltsExamId;

                var writingExamSectionList = iwritingExamSectionQueryFacade.GetWritingExamSectionListForUserPanel(writingExam.Id).ToList();
                writingExamSectionList = writingExamSectionList.OrderBy(a => a.TimerMinuties).ToList();

                var ieltsExamParticipantsDetail = iIeltsExamParticipantsDetailQueryFacade.GetIeltsExamParticipantsDetailById(pdId);

                var model = new IeltsWritingExamViewModel()
                {
                    ExamName = "WritingExam",
                    WritingExamId = writingExam.Id,
                    IeltsExamParticipantId = ieltsExamParticipantsDetail.IeltsExamParticipantsId,
                    IeltsWritingSectionViewModel = new List<IeltsWritingSectionViewModel>()
                };
                foreach (var item in writingExamSectionList)
                {
                    var child = new IeltsWritingSectionViewModel()
                    {
                        SectionId = item.Id,
                        SectionTitle = item.Title,
                        WritingTopic = item.WritingTopic,
                        TimerMinuties = item.TimerMinuties,
                    };
                    model.IeltsWritingSectionViewModel.Add(child);
                }

                ViewBag.WritingExamId = writingExamSectionList.First().WritingExamId;
                ViewBag.HasError = false;
                return View(model);
            }
            catch (Exception)
            {

                ModelState.AddModelError("IeltsExamWritingPageException", "There is a Problem. Please contact the support team");
                ViewBag.HasError = true;
                return View();
            }
        }

        [HttpPost]
        public ActionResult IeltsExamWritingPage(IeltsWritingExamViewModel model)
        {
            try
            {
                WritingUserAnswerCommand command = new WritingUserAnswerCommand();

                IList<AddWritingUserAnswerCommand> repository = new List<AddWritingUserAnswerCommand>();
                foreach (var item in model.IeltsWritingSectionViewModel)
                {
                    AddWritingUserAnswerCommand buffer = AddResponse(item.SectionId, item.Value,item.File);
                    repository.Add(buffer);
                }

                command.addWritingUserAnswerCommand = repository;
                iWritingUserAnswerCommandFacade.WritingUserAnswer(command);

                return RedirectToAction("WritingExamCompleted", new { writingExamCompleted = true });
            }
            catch (Exception)
            {
                return RedirectToAction("WritingExamCompleted", new { writingExamCompleted = false });
            }
        }
        public ActionResult WritingExamCompleted(bool writingExamCompleted)
        {
            ViewBag.CompletionStatus = writingExamCompleted;
            return View();
        }

        public AddWritingUserAnswerCommand AddResponse(Guid sectionId, string text,IFormFile file)
        {
            AddWritingUserAnswerCommand command = new AddWritingUserAnswerCommand();
            command.CustomerId =  new System.Guid(userManager.GetUserId(User));
            command.RegisterDateTime = DateTime.Now;
            command.WritingExamSectionId = sectionId;
            command.AnswerText = SaveFile(file);
            command.IsActive = true;
            command.IsDeleted = false;
            return command;
        }
        public string SaveFile(IFormFile file)
        {
            var filename = Guid.NewGuid() + Path.GetExtension(file.FileName).ToLower();
            var path = Path.Combine(root.WebRootPath, "FileforWritingAnswers", filename);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return $"{"https://userpanel.bpvielts.com/FileforWritingAnswers/"}{filename}";
        }

    }
}
