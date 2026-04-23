using ExamContext.Ielts.Aplication.Contracts.ParticipantsAggregate;
using ExamContext.Ielts.Facade.Contracts.ParticipantsAggregate;
using ExamContext.Listening.Aplication.Contracts.ListeningUserAnswerAggregate;
using ExamContext.Listening.Facade.Contracts.ListeningUserAnswerAggregate;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ParticipantsAggregate;
using ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningExamAggregate;
using ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningQuestionAggregate;
using Ielts.Common.GeneralClass;
using IeltsProject.Presentation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IeltsProject.Presentation.Controllers
{
    public class IeltsExamListeningController : Controller
    {        
        private readonly IListeningQuestionQueryFacade iListeningQuestionQueryFacade;
        private readonly IListeningExamQueryFacade iListeningExamQueryFacade;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IListeningUserAnswerCommandFacade iListeningUserAnswerCommandFacade;
        private readonly IIeltsExamParticipantsDetailFacade iIeltsExamParticipantsDetailFacade;
        private readonly IIeltsExamParticipantsDetailQueryFacade iIeltsExamParticipantsDetailQueryFacade;
        public IeltsExamListeningController(IListeningQuestionQueryFacade iListeningQuestionQueryFacade,
            IListeningExamQueryFacade iListeningExamQueryFacade,
            UserManager<ApplicationUser> userManager,
            IListeningUserAnswerCommandFacade iListeningUserAnswerCommandFacade,
            IIeltsExamParticipantsDetailFacade iIeltsExamParticipantsDetailFacade,
            IIeltsExamParticipantsDetailQueryFacade iIeltsExamParticipantsDetailQueryFacade)
        {
            this.iListeningQuestionQueryFacade = iListeningQuestionQueryFacade;
            this.iListeningExamQueryFacade = iListeningExamQueryFacade;
            this.userManager = userManager;
            this.iListeningUserAnswerCommandFacade = iListeningUserAnswerCommandFacade;
            this.iIeltsExamParticipantsDetailFacade = iIeltsExamParticipantsDetailFacade;
            this.iIeltsExamParticipantsDetailQueryFacade = iIeltsExamParticipantsDetailQueryFacade;
        }

        public IActionResult IeltsExamListeningPrePage(Guid id, Guid pdId)
        {
            var listeningExam = iListeningExamQueryFacade.GetListeningExamForUserPanel(id);

            ViewBag.id = id;
            ViewBag.pdId = pdId;

            return View(listeningExam);
        }
        public IActionResult IeltsExamListeningPage(Guid id, Guid pdId)
        {
            try
            {
                ViewBag.HasError = false;
                //------
                UpdateIeltsExamParticipantsDetailCommand updateIeltsExamParticipantsDetailCommand = new UpdateIeltsExamParticipantsDetailCommand();
                updateIeltsExamParticipantsDetailCommand.Id = pdId;
                updateIeltsExamParticipantsDetailCommand.ListeningExamIsGive = true;
                updateIeltsExamParticipantsDetailCommand.ListeningExamStartDateTime = DateTime.Now;

                iIeltsExamParticipantsDetailFacade.UpdateIeltsExamParticipantsDetail(updateIeltsExamParticipantsDetailCommand);
                //------
                var listeningExam = iListeningExamQueryFacade.GetListeningExamForUserPanel(id);

                ViewBag.IeltsExamId = listeningExam.IeltsExamId;

                var listeningQuestionList = iListeningQuestionQueryFacade.GetListeningQuestionUserPanelList(id);
                listeningQuestionList = listeningQuestionList.OrderBy(a => a.ListeningExamQuestionBlockOrderNo).OrderBy(a => a.ListeningExamSectionOrderNo).ToList();

                var ieltsExamParticipantsDetail = iIeltsExamParticipantsDetailQueryFacade.GetIeltsExamParticipantsDetailById(pdId);

                var model = new IeltsListeningExamViewModel()
                {
                    ExamName = "ListeningExam",
                    ListeningExamId = listeningExam.Id,
                    IeltsExamParticipantId = ieltsExamParticipantsDetail.IeltsExamParticipantsId,
                    VoiceSource = listeningExam.VoiceSource,
                    IeltsListeningQuestionViewModel = new List<IeltsListeningQuestionViewModel>()
                };
                foreach (var item in listeningQuestionList)
                {
                    var child = new IeltsListeningQuestionViewModel()
                    {
                        QuestionId = item.Id,
                        QuestionTypeId = item.ListeningQuestionTypeId,
                        AnswerValue = item.Id,
                        QuestionTitle = item.Title,
                        IeltsListeningAnswerViewModel = new List<IeltsListeningAnswerViewModel>(),
                        ListeningExamSectionId = item.ListeningExamSectionId,
                        ListeningExamSectionOrderNo = item.ListeningExamSectionOrderNo,
                        ListeningExamSectionTitle = item.ListeningExamSectionTitle,
                        ListeningExamQuestionBlockId = item.ListeningExamQuestionBlockId,
                        ListeningExamQuestionBlockOrderNo = item.ListeningExamQuestionBlockOrderNo,
                        ListeningExamQuestionBlockTitle = item.ListeningExamQuestionBlockTitle,
                        ListeningExamQuestionBlockDescription = item.ListeningExamQuestionBlockDescription
                    };
                    model.IeltsListeningQuestionViewModel.Add(child);
                    foreach (var ans in item.ListeningQuestionAnswers)
                    {
                        child.IeltsListeningAnswerViewModel.Add(new IeltsListeningAnswerViewModel()
                        {
                            AnswerId = ans.Id,
                            AnswerTitle = ans.Title
                        });
                    }
                }
                               
                ViewBag.HasError = false;
                return View(model);
            }
            catch (Exception)
            {

                ModelState.AddModelError("IeltsExamListeningPageException", "There is a Problem. Please contact the support team");
                ViewBag.HasError = true;
                return View();
            }
        }

        [HttpPost]
        public IActionResult IeltsExamListeningPage(IeltsListeningExamViewModel model) 
        {
            try
            {
                ListeningUserAnswerCommand command = new ListeningUserAnswerCommand();

                IList<AddListeningUserAnswerCommand> repository = new List<AddListeningUserAnswerCommand>();

                foreach (var item in model.IeltsListeningQuestionViewModel)
                {
                    if (item.QuestionTypeId == ListeningQuestionTypeList.CheckBox)
                    {
                        foreach (var itemCheckBox in item.IeltsListeningAnswerViewModel.Where(a => a.Checked == true))
                        {
                            AddListeningUserAnswerCommand buffer = AddResponse(item.QuestionId, model.ListeningExamId, model.IeltsExamParticipantId, itemCheckBox.AnswerId, null);
                            repository.Add(buffer);
                        }
                    }
                    else if (item.QuestionTypeId == ListeningQuestionTypeList.RadioButton)
                    {
                        AddListeningUserAnswerCommand buffer = AddResponse(item.QuestionId, model.ListeningExamId, model.IeltsExamParticipantId, item.AnswerValue, null);
                        repository.Add(buffer);
                    }
                    else if (item.QuestionTypeId == ListeningQuestionTypeList.ComboBox)
                    {
                        AddListeningUserAnswerCommand buffer = AddResponse(item.QuestionId, model.ListeningExamId, model.IeltsExamParticipantId, item.AnswerValue, null);
                        repository.Add(buffer);
                    }
                    else if (item.QuestionTypeId == ListeningQuestionTypeList.TextBox)
                    {
                        AddListeningUserAnswerCommand buffer = AddResponse(item.QuestionId, model.ListeningExamId, model.IeltsExamParticipantId, null, item.Value);
                        repository.Add(buffer);
                    }
                    else if (item.QuestionTypeId == ListeningQuestionTypeList.TextArea)
                    {
                        AddListeningUserAnswerCommand buffer = AddResponse(item.QuestionId, model.ListeningExamId, model.IeltsExamParticipantId, null, item.Value);
                        repository.Add(buffer);
                    }
                }
                command.addListeningUserAnswerCommand = repository;
                iListeningUserAnswerCommandFacade.ListeningUserAnswer(command);

                //updateCustomerSurveyStatus(model.ProductSurveyId);
                return RedirectToAction("ListeningExamCompleted", new { onlineListeningExamCompleted = true });
            }
            catch (Exception)
            {

                return RedirectToAction("ListeningExamCompleted", new { onlineListeningExamCompleted = false });
            }
        }
        public ActionResult ListeningExamCompleted(bool onlineListeningExamCompleted)
        {
            ViewBag.CompletionStatus = onlineListeningExamCompleted;
            return View();
        }

        public AddListeningUserAnswerCommand AddResponse(Guid questionId,
            Guid listeningExamId,
            Guid ieltsExamParticipantId,
            Guid? answerId,
            string text)
        {
            var customerId = new System.Guid(userManager.GetUserId(User));

            AddListeningUserAnswerCommand command = new AddListeningUserAnswerCommand();
            //command.TrackingCode = ...; // or username
            command.ListeningExamId = listeningExamId;
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
