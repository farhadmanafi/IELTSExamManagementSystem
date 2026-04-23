using ExamContext.Accounting.Aplication.Contracts.AccountingAggregate;
using ExamContext.Accounting.Facade.Contracts.AccountingAggregate;
using ExamContext.Ielts.Aplication.Contracts.ResualtAggregarte;
using ExamContext.Ielts.Facade.Contracts.ResualtAggregarte;
using ExamContext.OnlinePlacement.Aplication.Contracts.ParticipantsAggregate;
using ExamContext.OnlinePlacement.Aplication.Contracts.PlacementUserAnswerAggregate;
using ExamContext.OnlinePlacement.Aplication.Contracts.PlacementUserScoreAggregate;
using ExamContext.OnlinePlacement.Facade.Contracts.ParticipantsAggregate;
using ExamContext.OnlinePlacement.Facade.Contracts.PlacementUserAnswerAggregate;
using ExamContext.OnlinePlacement.Facade.Contracts.PlacementUserScoreAggregate;
using ExamContext.ReadModel.Queries.Contracts.AccountingContext.AccountingAggregate;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.ParticipantsAggregate;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementExamAggregate;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementQuestionAggregate;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementQuestionAggregate.DataContracts;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementUserAnswerAggregate;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementUserScoreAggregate;
using Ielts.Common.GeneralClass;
using IeltsProject.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IeltsProject.Presentation.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Authorize]
    public class OnlinePlacementController : Controller
    {
        string merchant = "936dcbd6-5576-41b8-a234-059d22035780";
        public static string amount = "0";
        string authority;
        public static Guid placementExamId = new Guid();
        public static Guid participantsId = new Guid();
        string description = "Placement Exam Payment";
        //string callbackurl = "https://localhost:44386/OnlinePlacement/VerifyByHttpClient";
        //string callbackurl = "https://userpanel.bpvielts.com/OnlinePlacement/VerifyByHttpClient";

        #if DEBUG
                string callbackurl = "https://localhost:44386/OnlinePlacement/VerifyByHttpClient";
        #else
              string callbackurl = "https://userpanel.bpvielts.com/OnlinePlacement/VerifyByHttpClient";
        #endif


        private readonly IPlacementExamQueryFacade iPlacementExamQueryFacade;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPlacementUserScoreQueryFacade iPlacementUserScoreQueryFacade;
        private readonly IPlacementQuestionQueryFacade iPlacementQuestionQueryFacade;
        private readonly IPlacementUserAnswerFacade iPlacementUserAnswerFacade;
        private readonly IPlacementUserAnswerQueryFacade iPlacementUserAnswerQueryFacade;
        private readonly IPlacementUserScoreFacade iPlacementUserScoreFacade;
        private readonly IBankTransactionCommandFacade iBankTransactionCommandFacade;
        private readonly IBankTransactionQueryFacade iBankTransactionQueryFacade;
        private readonly IPlacementExamParticipantsFacade iPlacementExamParticipantsFacade;
        private readonly IOnlinePlacementParticipantsQueryFacade iOnlinePlacementParticipantsQueryFacade;
        private readonly IUserResualtFacade iUserResualtFacade;
        public OnlinePlacementController(IPlacementExamQueryFacade iPlacementExamQueryFacade,
            UserManager<ApplicationUser> userManager,
            IPlacementUserScoreQueryFacade iPlacementUserScoreQueryFacade,
            IPlacementQuestionQueryFacade iPlacementQuestionQueryFacade,
            IPlacementUserAnswerFacade iPlacementUserAnswerFacade,
            IPlacementUserAnswerQueryFacade iPlacementUserAnswerQueryFacade,
            IPlacementUserScoreFacade iPlacementUserScoreFacade,
            IBankTransactionCommandFacade iBankTransactionCommandFacade,
            IBankTransactionQueryFacade iBankTransactionQueryFacade,
            IPlacementExamParticipantsFacade iPlacementExamParticipantsFacade,
            IOnlinePlacementParticipantsQueryFacade iOnlinePlacementParticipantsQueryFacade,
            IUserResualtFacade iUserResualtFacade)
        {
            this.iPlacementExamQueryFacade = iPlacementExamQueryFacade;
            this.userManager = userManager;
            this.iPlacementUserScoreQueryFacade = iPlacementUserScoreQueryFacade;
            this.iPlacementQuestionQueryFacade = iPlacementQuestionQueryFacade;
            this.iPlacementUserAnswerFacade = iPlacementUserAnswerFacade;
            this.iPlacementUserAnswerQueryFacade = iPlacementUserAnswerQueryFacade;
            this.iPlacementUserScoreFacade = iPlacementUserScoreFacade;
            this.iBankTransactionCommandFacade = iBankTransactionCommandFacade;
            this.iBankTransactionQueryFacade = iBankTransactionQueryFacade;
            this.iPlacementExamParticipantsFacade = iPlacementExamParticipantsFacade;
            this.iOnlinePlacementParticipantsQueryFacade = iOnlinePlacementParticipantsQueryFacade;
            this.iUserResualtFacade = iUserResualtFacade;
        }

        public IActionResult OnlinePlacementList()
        {
            var placementExamList = iPlacementExamQueryFacade.GetPlacementExamActiveList();

            return View(placementExamList);
        }

        public IActionResult OnlinePlacementRegisterPage(Guid id)
        {
            //var customerId = new System.Guid(userManager.GetUserId(User));

            //var placementUserScoreList = iPlacementUserScoreQueryFacade.GetPlacementUserScoreByCustomer(customerId, id);
            //if(placementUserScoreList != null)
            //    placementUserScoreList.ExamDate_Persian = DateConverter.MiladiToShamsiConvert(placementUserScoreList.ExamDate);

            ViewBag.PlacementExamId = id;

            var placementExam = iPlacementExamQueryFacade.GetPlacementExamForUserpanel(id);

            return View(placementExam);
        }

        //OnlinePlacementRegisterPageFinal
        //************************************
        public ActionResult ShowResultStatus(bool CompletionFlag, Guid? id)
        {
            ViewBag.CompletionStatus = CompletionFlag;
            ViewBag.PlacementExamId = id;
            return View();
        }

        public async Task<IActionResult> PlacementExamRegisterPageFinal(Guid id)
        {
            try
            {
                ViewBag.PlacementExamId = id;
                placementExamId = id;

                var placementExam = iPlacementExamQueryFacade.GetPlacementExamForUserpanel(id);
                var customerId = new System.Guid(userManager.GetUserId(User));

                AddPlacementExamParticipantsCommand addPlacementExamParticipantsCommand = new AddPlacementExamParticipantsCommand();
                addPlacementExamParticipantsCommand.PlacementExamId = id;
                addPlacementExamParticipantsCommand.PlacementExamOrederNumber = 11;
                addPlacementExamParticipantsCommand.PlacementExamPriceId = placementExam.PlacementExamPriceId;
                addPlacementExamParticipantsCommand.RegisterDate = DateTime.Now;
                addPlacementExamParticipantsCommand.CustomerId = customerId;
                addPlacementExamParticipantsCommand.PlacementExamParticipantsStatusId = PlacementExamParticipantsStatusList.PreRegister;

                //PlacementExamParticipantsDetailDto placementExamParticipantsDetailDto = new PlacementExamParticipantsDetailDto();
                //placementExamParticipantsDetailDto.ListeningExamId = placementExam.ListeningExamId;
                //placementExamParticipantsDetailDto.ReadingExamId = placementExam.ReadingExamId;
                //placementExamParticipantsDetailDto.WritingExamId = placementExam.WritingExamId;
                //placementExamParticipantsDetailDto.SpeakingExamId = placementExam.SpeakigExamId;

                //addPlacementExamParticipantsCommand.placementExamParticipantsDetailDto = placementExamParticipantsDetailDto;

                participantsId = iPlacementExamParticipantsFacade.AddPlacementExamParticipants(addPlacementExamParticipantsCommand);

                //****
                AddUserResualtCommand addUserResualtCommand = new AddUserResualtCommand();
                addUserResualtCommand.CustomerId = customerId;
                addUserResualtCommand.ParticipantsId = participantsId;
                addUserResualtCommand.UserId = customerId;
                addUserResualtCommand.IsActive = true;
                addUserResualtCommand.IsDeleted = false;
                addUserResualtCommand.IeltsResualtLevelId = new Guid("4EC15CE2-6E8D-4B90-9AA4-07707CCF6B77");

                iUserResualtFacade.AddUserResualt(addUserResualtCommand);
                //****
                //**
                long? price = placementExam.PriceAmount - ((placementExam.PriceAmount / 100) * placementExam.DiscontentAmount);
                //**
                //**********************
                Guid bankTransactionTypeId = BankTransactionTypeList.SendToBank;
                Guid examTypeId = ExamTypeList.OnlinePlacement;
                InsertPayment(price, "زرین پال", participantsId, bankTransactionTypeId, examTypeId);

                amount = price.ToString();
                using (var client = new HttpClient())
                {
                    RequestParameters parameters = new RequestParameters(merchant, amount, description, callbackurl, "", "");
                    var json = JsonConvert.SerializeObject(parameters);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(URLs.requestUrl, content);
                    string responseBody = await response.Content.ReadAsStringAsync();
                    JObject jo = JObject.Parse(responseBody);
                    string errorscode = jo["errors"].ToString();
                    JObject jodata = JObject.Parse(responseBody);
                    string dataauth = jodata["data"].ToString();

                    if (dataauth != "[]")
                    {
                        authority = jodata["data"]["authority"].ToString();
                        string gatewayUrl = URLs.gateWayUrl + authority;
                        return Redirect(gatewayUrl);
                    }
                    else
                    {
                        return BadRequest("error " + errorscode);
                    }
                }

                //RequestParameters Parameters = new RequestParameters(merchant, amount, description, callbackurl, "", "");

                //amount = price.ToString();
                //var client = new RestClient(URLs.requestUrl);
                //Method method = Method.Post;
                //var request = new RestRequest("", method);
                //request.AddHeader("accept", "application/json");
                //request.AddHeader("content-type", "application/json");
                //request.AddJsonBody(Parameters);
                //var requestresponse = client.ExecuteAsync(request);
                //JObject jo = JObject.Parse(requestresponse.Result.Content);
                //string errorscode = jo["errors"].ToString();
                //JObject jodata = JObject.Parse(requestresponse.Result.Content);
                //string dataauth = jodata["data"].ToString();

                //if (dataauth != "[]")
                //{
                //    authority = jodata["data"]["authority"].ToString();
                //    string gatewayUrl = URLs.gateWayUrl + authority;
                //    return Redirect(gatewayUrl);
                //}
                //else
                //{
                //    return BadRequest("error " + errorscode);
                //}
                //**********************

                ViewBag.HasError = false;
                return View();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("PlacementExamRegisterException", e.Message);
                ViewBag.HasError = true;
                return View();
            }
        }

        public async Task<IActionResult> VerifyByHttpClient()
        {
            try
            {
                VerifyParameters parameters = new VerifyParameters();
                if (HttpContext.Request.Query["Authority"] != "")
                {
                    authority = HttpContext.Request.Query["Authority"];
                }
                parameters.authority = authority;
                parameters.amount = amount;
                parameters.merchant_id = merchant;
                using (HttpClient client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(parameters);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(URLs.verifyUrl, content);
                    string responseBody = await response.Content.ReadAsStringAsync();
                    JObject jodata = JObject.Parse(responseBody);
                    string data = jodata["data"].ToString();
                    JObject jo = JObject.Parse(responseBody);
                    string errors = jo["errors"].ToString();
                    if (data != "[]")
                    {
                        string refid = jodata["data"]["ref_id"].ToString();
                        ViewBag.code = refid;

                        Guid bankTransactionTypeId = BankTransactionTypeList.SucsessTransaction;
                        UpdatePayment(participantsId, refid, bankTransactionTypeId);
                        return View();
                    }
                    else if (errors != "[]")
                    {

                        string errorscode = jo["errors"]["code"].ToString();

                        return BadRequest($"error code {errorscode}");

                    }
                }
                //VerifyParameters parameters = new VerifyParameters();
                //if (HttpContext.Request.Query["Authority"] != "")
                //{
                //    authority = HttpContext.Request.Query["Authority"];
                //}
                //parameters.authority = authority;
                //parameters.amount = amount;
                //parameters.merchant_id = merchant;
                //using (HttpClient client = new HttpClient())
                //{
                //    var json = JsonConvert.SerializeObject(parameters);
                //    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                //    HttpResponseMessage response = await client.PostAsync(URLs.verifyUrl, content);
                //    string responseBody = await response.Content.ReadAsStringAsync();
                //    JObject jodata = JObject.Parse(responseBody);
                //    string data = jodata["data"].ToString();
                //    JObject jo = JObject.Parse(responseBody);
                //    string errors = jo["errors"].ToString();
                //    if (data != "[]")
                //    {
                //        string refid = jodata["data"]["ref_id"].ToString();
                //        ViewBag.code = refid;
                //        UpdatePayment(placementExamParticipantsId);
                //        return View();
                //    }
                //    else if (errors != "[]")
                //    {
                //        string errorscode = jo["errors"]["code"].ToString();
                //        return BadRequest($"error code {errorscode}");
                //    }
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return NotFound();
        }

        //**
        #region ثبت اطلاعات اولیه پرداخت در دیتابیس
        private int InsertPayment(long? price,
            string bankName,
            Guid placementExamParticipantsId,
            Guid bankTransactionTypeId,
            Guid examTypeId)
        {
            int paymentId = 0;
            try
            {
                Guid customerId = new System.Guid(userManager.GetUserId(User));

                AddBankTransactionCommand addBankTransactionCommand = new AddBankTransactionCommand();
                addBankTransactionCommand.CustomerAccountNumber = "";
                addBankTransactionCommand.BankTransactionTypeId = bankTransactionTypeId;
                addBankTransactionCommand.ExamTypeId = examTypeId;
                addBankTransactionCommand.PaymentPriceAmount = (long)price;
                addBankTransactionCommand.CustomerId = customerId;
                addBankTransactionCommand.BankTransactionCode = "BankTransactionCode";
                addBankTransactionCommand.BankName = bankName;
                addBankTransactionCommand.ParticipantsId = placementExamParticipantsId;
                addBankTransactionCommand.PaymentFinished = false;
                addBankTransactionCommand.PaymentDateTime = DateTime.Now;
                addBankTransactionCommand.IsActive = true;
                addBankTransactionCommand.IsDeleted = false;

                iBankTransactionCommandFacade.AddBankTransaction(addBankTransactionCommand);


                return 1;

            }
            catch (Exception ex)
            {
                return 0;
            }

            return paymentId;
        }

        private int UpdatePayment(Guid placementExamParticipantsId, string bankTransactionCode, Guid bankTransactionTypeId)
        {
            int paymentId = 0;
            try
            {
                Guid customerId = new System.Guid(userManager.GetUserId(User));

                UpdatePlacementExamParticipantsCommand updatePlacementExamParticipantsCommand = new UpdatePlacementExamParticipantsCommand();
                updatePlacementExamParticipantsCommand.Id = placementExamParticipantsId;
                updatePlacementExamParticipantsCommand.PlacementExamParticipantsStatusId = PlacementExamParticipantsStatusList.FinalRegister;

                iPlacementExamParticipantsFacade.UpdatePlacementExamParticipants(updatePlacementExamParticipantsCommand);


                UpdateBankTransactionByParticipantsIdCommand updateBankTransactionByParticipantsIdCommand = new UpdateBankTransactionByParticipantsIdCommand();
                updateBankTransactionByParticipantsIdCommand.ParticipantsId = placementExamParticipantsId;
                updateBankTransactionByParticipantsIdCommand.BankTransactionCode = bankTransactionCode;
                updateBankTransactionByParticipantsIdCommand.PaymentFinished = true;
                updateBankTransactionByParticipantsIdCommand.BankTransactionTypeId = bankTransactionTypeId;

                iBankTransactionCommandFacade.UpdateBankTransactionByParticipantsId(updateBankTransactionByParticipantsIdCommand);


                return 1;

            }
            catch (Exception ex)
            {
                return 0;
            }

            return paymentId;
        }
        #endregion

        #region متد ویرایش پرداخت 

        private void UpdatePayment(Guid paymentId, string vresult, long saleReferenceId, string refId, bool paymentFinished = false)
        {
            UpdateBankTransactionCommand updateBankTransactionCommand = new UpdateBankTransactionCommand();
            updateBankTransactionCommand.Id = paymentId;
            updateBankTransactionCommand.PaymentFinished = paymentFinished;

            iBankTransactionCommandFacade.UpdateBankTransaction(updateBankTransactionCommand);
        }
        #endregion

        #region پیدا کردن مبلغ خرید
        private long FindAmountPayment(Guid paymentId)
        {

            var data = iBankTransactionQueryFacade.GetBankTransactionByPaymentId(paymentId);

            return data.PriceAmount;
        }
        #endregion
        //**
        //************************************
        public ActionResult OnlinePlacementIeltsExamList()
        {

            return View();
        }
        public ActionResult CustomerOnlinePlacementExamListGridData(DataTableAjaxPostModel model)
        {
            var customerId = new System.Guid(userManager.GetUserId(User));

            var ieltsExamResult = iOnlinePlacementParticipantsQueryFacade.GetOnlinePlacementFilteringListByCustomerId(ref model, customerId);
            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = ieltsExamResult
            });
        }

        public IActionResult OnlinePlacementExamPage(System.Guid id, Guid pId)
        {
            //
            UpdatePlacementExamParticipantsCommand updateIeltsExamParticipantsDetailCommand = new UpdatePlacementExamParticipantsCommand();
            updateIeltsExamParticipantsDetailCommand.Id = pId;
            updateIeltsExamParticipantsDetailCommand.PlacementExamParticipantsStatusId = PlacementExamParticipantsStatusList.GiveExam;

            iPlacementExamParticipantsFacade.UpdatePlacementExamParticipants(updateIeltsExamParticipantsDetailCommand);
            //------
            var placementQuestionList = iPlacementQuestionQueryFacade.GetPlacementQuestionByPlacementExamUserPanelList(id);
            var model = new ExamViewModel()
            {
                ExamName = "Exam1",
                ExamId = placementQuestionList.First().PlacementExamtId,
                QuestionViewModel = new List<QuestionViewModel>()
            };
            foreach (var item in placementQuestionList)
            {
                var child = new QuestionViewModel()
                {
                    QuestionId = item.Id,
                    QuestionTypeId = item.PlacementQuestionTypeId,
                    AnswerValue = item.Id,
                    QuestionTitle = item.Title,
                    AnswerViewModel = new List<AnswerViewModel>() 
                };
                model.QuestionViewModel.Add(child);
                foreach (var ans in item.PlacementQuestionAnswers)
                {
                    child.AnswerViewModel.Add(new AnswerViewModel()
                    {
                        AnswerId = ans.Id,
                        AnswerTitle = ans.Title
                    });
                }
            }
            ViewBag.PlacementExamtId = placementQuestionList.First().PlacementExamtId;
            return View(model);
        }

        [HttpPost]
        public IActionResult OnlinePlacementExamPage(ExamViewModel model)
        {
            try
            {
                var customerId = new System.Guid(userManager.GetUserId(User));

                PlacementUserAnswerCommand command = new PlacementUserAnswerCommand();

                AddPlacementUserScoreCommand addPlacementUserScoreCommand = new AddPlacementUserScoreCommand();

                addPlacementUserScoreCommand.PlacementExamId = model.ExamId;
                addPlacementUserScoreCommand.CustomerId = customerId;
                addPlacementUserScoreCommand.LevelScoreId = new Guid("2cbde957-8b86-4376-9e18-4d075b448a61");
                addPlacementUserScoreCommand.ExamDate = DateTime.Now;
                addPlacementUserScoreCommand.IsActive = true;
                addPlacementUserScoreCommand.IsDeleted = false;

                command.addPlacementUserScoreCommand = addPlacementUserScoreCommand;

                IList<AddPlacementUserAnswerCommand> repository = new List<AddPlacementUserAnswerCommand>();

                foreach (var item in model.QuestionViewModel)
                {
                    if (item.QuestionTypeId == PlacementQuestionTypeList.CheckBox)
                    {
                        foreach (var itemCheckBox in item.AnswerViewModel.Where(a => a.Checked == true))
                        {
                            AddPlacementUserAnswerCommand buffer = AddResponse(item.QuestionId, itemCheckBox.AnswerId, null);
                            repository.Add(buffer);
                        }
                    }
                    else if (item.QuestionTypeId == PlacementQuestionTypeList.RadioButton)
                    {
                        AddPlacementUserAnswerCommand buffer = AddResponse(item.QuestionId, item.AnswerValue, null);
                        repository.Add(buffer);
                    }
                    else if (item.QuestionTypeId == PlacementQuestionTypeList.ComboBox)
                    {
                        AddPlacementUserAnswerCommand buffer = AddResponse(item.QuestionId, item.AnswerValue, null);
                        repository.Add(buffer);
                    }
                    else if (item.QuestionTypeId == PlacementQuestionTypeList.TextBox)
                    {
                        AddPlacementUserAnswerCommand buffer = AddResponse(item.QuestionId, null, item.Value);
                        repository.Add(buffer);
                    }
                    else if (item.QuestionTypeId == PlacementQuestionTypeList.TextArea)
                    {
                        AddPlacementUserAnswerCommand buffer = AddResponse(item.QuestionId, null, item.Value);
                        repository.Add(buffer);
                    }
                }
                command.addPlacementUserAnswerList = repository;

                Guid placementUserScoreId = iPlacementUserAnswerFacade.AddPlacementUserAnswer(command);

                UpdateCustomerSurveyStatus(placementUserScoreId);

                return RedirectToAction("OnlinePlacementExamCompleted", new { onlinePlacementExamCompleted = true });
            }
            catch (Exception)
            {

                return RedirectToAction("OnlinePlacementExamCompleted", new { onlinePlacementExamCompleted = false });
            }
        }

        //***
        public void UpdateCustomerSurveyStatus(Guid placementUserScoreId)
        {
            var placementUserAnswerList = iPlacementUserAnswerQueryFacade.GetPlacementUserAnswerByPlacementUserScoreIdListUserPanel(placementUserScoreId);

            int userCurrentAnswer = 0;
            Guid userLevel = OnlinePlacementUserScoreLevelScore.Level_Processing;
            foreach (var item in placementUserAnswerList)
            {
                if (item.IsCorrectAnswer == true)
                    ++userCurrentAnswer;

            }
            if (userCurrentAnswer >= 0 && userCurrentAnswer <= 5)
            {
                userLevel = OnlinePlacementUserScoreLevelScore.Level_A1;
            }
            else if (userCurrentAnswer >= 6 && userCurrentAnswer <= 10)
            {
                userLevel = OnlinePlacementUserScoreLevelScore.Level_A2;
            }
            else if (userCurrentAnswer >= 11 && userCurrentAnswer <= 15)
            {
                userLevel = OnlinePlacementUserScoreLevelScore.Level_B1;
            }
            else if (userCurrentAnswer >= 16 && userCurrentAnswer <= 19)
            {
                userLevel = OnlinePlacementUserScoreLevelScore.Level_B2;
            }
            else if (userCurrentAnswer >= 20 && userCurrentAnswer <= 22)
            {
                userLevel = OnlinePlacementUserScoreLevelScore.Level_C1;
            }
            else if (userCurrentAnswer >= 23 && userCurrentAnswer <= 25)
            {
                userLevel = OnlinePlacementUserScoreLevelScore.Level_C2;
            }

            UpdatePlacementUserScoreLevelCommand updatePlacementUserScoreLevelCommand = new UpdatePlacementUserScoreLevelCommand();
            updatePlacementUserScoreLevelCommand.Id = placementUserScoreId;
            updatePlacementUserScoreLevelCommand.LevelScoreId = userLevel;

            iPlacementUserScoreFacade.UpdatePlacementUserScoreLevel(updatePlacementUserScoreLevelCommand); 
            
        }
        //***

        public ActionResult OnlinePlacementExamCompleted(bool onlinePlacementExamCompleted) {

            ViewBag.CompletionStatus = onlinePlacementExamCompleted;
            return View();
        }

        public AddPlacementUserAnswerCommand AddResponse(Guid questionId, Guid? answerId, string text)
        {
            AddPlacementUserAnswerCommand command = new AddPlacementUserAnswerCommand();
            //command.TrackingCode = ...; // or username
            command.QuestionId = questionId;
            command.AnswerId = answerId;
            command.AnswerText = text;
            command.IsActive = true;
            command.IsDeleted = false;
            return command;
            //_userAnswerCommandFacade.AddUserAnswer(command);
        }

        #region PlacementCustomerScoreList
        public IActionResult PlacementCustomerScoreList()
        {
            var customerId = new System.Guid(userManager.GetUserId(User));
            ViewBag.CustomerId = customerId;
            return View();
        }

        public ActionResult PlacementCustomerScoreData(DataTableAjaxPostModel model, Guid id)
        {
            var placementUserScoreList = iPlacementUserScoreQueryFacade.GetPlacementUserScoreByCustomerIdList(ref model, id);

            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = placementUserScoreList
            });
        }
        #endregion

        #region OnlinePlacementCustomerScoreDetail
        public IActionResult OnlinePlacementCustomerScoreDetail(Guid id)
        {
            ViewBag.PlacementCustomerScoreId = id;
            return View();
        }

        public ActionResult OnlinePlacementCustomerScoreDetailData(DataTableAjaxPostModel model, Guid id)
        {
            var placementUserScoreList = iPlacementUserAnswerQueryFacade.GetPlacementUserAnswerByPlacementUserScoreIdList(ref model, id);

            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = placementUserScoreList
            });
        }
        #endregion 

    }
}
