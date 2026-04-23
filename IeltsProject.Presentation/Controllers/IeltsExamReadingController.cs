using ExamContext.Ielts.Aplication.Contracts.ParticipantsAggregate;
using ExamContext.Ielts.Facade.Contracts.ParticipantsAggregate;
using ExamContext.Reading.Aplication.Contracts.ReadingUserAnswerAggregate;
using ExamContext.Reading.Facade.Contracts.ReadingUserAnswerAggregate;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ParticipantsAggregate;
using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingExamAggregate;
using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingQuestionAggregate;
using Ielts.Common.GeneralClass;
using IeltsProject.Presentation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IeltsProject.Presentation.Controllers
{
    public class IeltsExamReadingController : Controller
    {
        private readonly IReadingQuestionQueryFacade iReadingQuestionQueryFacade;
        private readonly IReadingExamQueryFacade iReadingExamQueryFacade;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IReadingUserAnswerCommandFacade iReadingUserAnswerCommandFacade;
        private readonly IIeltsExamParticipantsDetailFacade iIeltsExamParticipantsDetailFacade;
        private readonly IIeltsExamParticipantsDetailQueryFacade iIeltsExamParticipantsDetailQueryFacade;
        public IeltsExamReadingController(IReadingQuestionQueryFacade iReadingQuestionQueryFacade,
            IReadingExamQueryFacade iReadingExamQueryFacade,
            UserManager<ApplicationUser> userManager,
            IReadingUserAnswerCommandFacade iReadingUserAnswerCommandFacade,
            IIeltsExamParticipantsDetailFacade iIeltsExamParticipantsDetailFacade,
            IIeltsExamParticipantsDetailQueryFacade iIeltsExamParticipantsDetailQueryFacade)
        {
            this.iReadingQuestionQueryFacade = iReadingQuestionQueryFacade;
            this.iReadingExamQueryFacade = iReadingExamQueryFacade;
            this.userManager = userManager;
            this.iReadingUserAnswerCommandFacade = iReadingUserAnswerCommandFacade;
            this.iIeltsExamParticipantsDetailFacade = iIeltsExamParticipantsDetailFacade;
            this.iIeltsExamParticipantsDetailQueryFacade = iIeltsExamParticipantsDetailQueryFacade;
        }

        public IActionResult IeltsExamReadingPage(Guid id, Guid pdId)
        {
            try
            {
                UpdateIeltsExamParticipantsDetailCommand updateIeltsExamParticipantsDetailCommand = new UpdateIeltsExamParticipantsDetailCommand();
                updateIeltsExamParticipantsDetailCommand.Id = pdId;
                updateIeltsExamParticipantsDetailCommand.ReadingExamIsGive = true;
                updateIeltsExamParticipantsDetailCommand.ReadingExamStartDateTime = DateTime.Now;

                iIeltsExamParticipantsDetailFacade.UpdateIeltsExamParticipantsDetail(updateIeltsExamParticipantsDetailCommand);

                var ReadingExam = iReadingExamQueryFacade.GetReadingExamForUserPanel(id);

                var ReadingQuestionList = iReadingQuestionQueryFacade.GetReadingQuestionUserPanelList(ReadingExam.Id);
                ReadingQuestionList = ReadingQuestionList.OrderBy(a => a.ReadingExamQuestionBlockOrderNo).OrderBy(a => a.ReadingExamSectionOrderNo).ToList();

                var ieltsExamParticipantsDetail = iIeltsExamParticipantsDetailQueryFacade.GetIeltsExamParticipantsDetailById(pdId);

                var model = new IeltsReadingExamViewModel()
                {
                    ExamName = "ReadingExam",
                    ReadingExamId = ReadingExam.Id,
                    IeltsExamParticipantId = ieltsExamParticipantsDetail.IeltsExamParticipantsId,
                    IeltsReadingQuestionViewModel = new List<IeltsReadingQuestionViewModel>()
                };
                foreach (var item in ReadingQuestionList)
                {
                    var child = new IeltsReadingQuestionViewModel()
                    {
                        QuestionId = item.Id,
                        QuestionTypeId = item.ReadingQuestionTypeId,
                        AnswerValue = item.Id,
                        QuestionTitle = item.Title,
                        IeltsReadingAnswerViewModel = new List<IeltsReadingAnswerViewModel>(),
                        ReadingExamSectionId = item.ReadingExamSectionId,
                        ReadingExamSectionOrderNo = item.ReadingExamSectionOrderNo,
                        ReadingExamSectionTitle = item.ReadingExamSectionTitle,
                        ReadingExamSectionReadingText = item.ReadingExamSectionReadingText,
                        ReadingExamQuestionBlockId = item.ReadingExamQuestionBlockId,
                        ReadingExamQuestionBlockOrderNo = item.ReadingExamQuestionBlockOrderNo,
                        ReadingExamQuestionBlockTitle = item.ReadingExamQuestionBlockTitle,
                        ReadingExamQuestionBlockDescription = item.ReadingExamQuestionBlockDescription
                    };
                    model.IeltsReadingQuestionViewModel.Add(child);
                    foreach (var ans in item.ReadingQuestionAnswers)
                    {
                        child.IeltsReadingAnswerViewModel.Add(new IeltsReadingAnswerViewModel()
                        {
                            AnswerId = ans.Id,
                            AnswerTitle = ans.Title
                        });
                    }
                }

                ViewBag.HasError = false;
                return View("IeltsExamReadingPage", model);
            }
            catch (Exception)
            {

                ModelState.AddModelError("IeltsExamReadingPageException", "There is a Problem. Please contact the support team");
                ViewBag.HasError = true;
                return View();
            }
        }

        [HttpPost]
        public IActionResult IeltsExamReadingPage(IeltsReadingExamViewModel model)
        {
            try
            {
                var customerId = new System.Guid(userManager.GetUserId(User));

                ReadingUserAnswerCommand command = new ReadingUserAnswerCommand();

                IList<AddReadingUserAnswerCommand> repository = new List<AddReadingUserAnswerCommand>();

                foreach (var item in model.IeltsReadingQuestionViewModel)
                {
                    if (item.QuestionTypeId == ReadingQuestionTypeList.CheckBox)
                    {
                        foreach (var itemCheckBox in item.IeltsReadingAnswerViewModel.Where(a => a.Checked == true))
                        {
                            AddReadingUserAnswerCommand buffer = AddResponse(item.QuestionId, model.ReadingExamId, model.IeltsExamParticipantId, itemCheckBox.AnswerId, null);
                            repository.Add(buffer);
                        }
                    }
                    else if (item.QuestionTypeId == ReadingQuestionTypeList.RadioButton)
                    {
                        AddReadingUserAnswerCommand buffer = AddResponse(item.QuestionId, model.ReadingExamId, model.IeltsExamParticipantId, item.AnswerValue, null);
                        repository.Add(buffer);
                    }
                    else if (item.QuestionTypeId == ReadingQuestionTypeList.ComboBox)
                    {
                        AddReadingUserAnswerCommand buffer = AddResponse(item.QuestionId, model.ReadingExamId, model.IeltsExamParticipantId, item.AnswerValue, null);
                        repository.Add(buffer);
                    }
                    else if (item.QuestionTypeId == ReadingQuestionTypeList.TextBox)
                    {
                        AddReadingUserAnswerCommand buffer = AddResponse(item.QuestionId, model.ReadingExamId, model.IeltsExamParticipantId, null, item.Value);
                        repository.Add(buffer);
                    }
                    else if (item.QuestionTypeId == ReadingQuestionTypeList.TextArea)
                    {
                        AddReadingUserAnswerCommand buffer = AddResponse(item.QuestionId, model.ReadingExamId, model.IeltsExamParticipantId, null, item.Value);
                        repository.Add(buffer);
                    }
                }
                command.addReadingUserAnswerCommand = repository;
                iReadingUserAnswerCommandFacade.ReadingUserAnswer(command);

                //updateCustomerSurveyStatus(model.ProductSurveyId);
                return RedirectToAction("ReadingExamCompleted", new { readingExamCompleted = true });
            }
            catch (Exception)
            {

                return RedirectToAction("ReadingExamCompleted", new { readingExamCompleted = false });
            }
        }
        public ActionResult ReadingExamCompleted(bool readingExamCompleted)
        {
            ViewBag.CompletionStatus = readingExamCompleted;
            return View();
        }

        public AddReadingUserAnswerCommand AddResponse(Guid questionId,
            Guid readingExamId,
            Guid ieltsExamParticipantId,
            Guid? answerId,
            string text)
        {
            var customerId = new System.Guid(userManager.GetUserId(User));

            AddReadingUserAnswerCommand command = new AddReadingUserAnswerCommand();
            //command.TrackingCode = ...; // or username
            command.ReadingExamId = readingExamId;
            command.IeltsExamParticipantId = ieltsExamParticipantId;
            command.QuestionId = questionId;
            command.AnswerId = answerId;
            command.AnswerText = text;
            command.CustomerId = customerId;
            command.IsActive = true;
            command.IsDeleted = false;
            return command;
            //_userAnswerCommandFacade.AddUserAnswer(command);
        }

    }
}
