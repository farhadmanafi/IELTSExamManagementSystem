using ExamContext.Accounting.Aplication.Contracts.AccountingAggregate;
using ExamContext.Accounting.Facade.Contracts.AccountingAggregate;
using ExamContext.Ielts.Aplication.Contracts.ParticipantsAggregate;
using ExamContext.Ielts.Aplication.Contracts.ResualtAggregarte;
using ExamContext.Ielts.Domain.Contracts.ParticipantsAggregate;
using ExamContext.Ielts.Facade.Contracts.ParticipantsAggregate;
using ExamContext.Ielts.Facade.Contracts.ResualtAggregarte;
using ExamContext.ReadModel.Queries.Contracts.AccountingContext.AccountingAggregate;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.IeltsAggregarte.IeltsAggregarte;
using Ielts.Common.GeneralClass;
using IeltsProject.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IeltsProject.Presentation.Controllers
{
    [Authorize]
    public class IeltsExamController : Controller
    {
        string merchant = "936dcbd6-5576-41b8-a234-059d22035780";
        public static string amount = "0";
        string authority;
        public static Guid ieltsId = new Guid();
        public static Guid participantsId = new Guid();
        string description = "Ielts Exam Payment";
        //string callbackurl = "https://localhost:44386/IeltsExam/VerifyByHttpClient";
        //string callbackurl = "https://userpanel.bpvielts.com/IeltsExam/VerifyByHttpClient";

        #if DEBUG
                string callbackurl = "https://localhost:44386/IeltsExam/VerifyByHttpClient";
        #else
                string callbackurl = "https://userpanel.bpvielts.com/IeltsExam/VerifyByHttpClient";
        #endif


        private readonly UserManager<ApplicationUser> userManager;
        private readonly IIeltsExamQueryFacade ieltsExamQueryFacade;
        private readonly IIeltsExamParticipantsFacade iIeltsExamParticipantsFacade;
        private readonly IBankTransactionCommandFacade iBankTransactionCommandFacade;
        private readonly IBankTransactionQueryFacade iBankTransactionQueryFacade;
        private readonly IUserResualtFacade iUserResualtFacade;
        public IeltsExamController(UserManager<ApplicationUser> userManager,
                                    IIeltsExamQueryFacade ieltsExamQueryFacade,
                                    IIeltsExamParticipantsFacade iIeltsExamParticipantsFacade,
                                    IBankTransactionCommandFacade iBankTransactionCommandFacade,
                                    IBankTransactionQueryFacade iBankTransactionQueryFacade,
                                    IUserResualtFacade iUserResualtFacade)
        {
            this.userManager = userManager;
            this.ieltsExamQueryFacade = ieltsExamQueryFacade;
            this.iIeltsExamParticipantsFacade = iIeltsExamParticipantsFacade;
            this.iBankTransactionCommandFacade = iBankTransactionCommandFacade;
            this.iBankTransactionQueryFacade = iBankTransactionQueryFacade;
            this.iUserResualtFacade = iUserResualtFacade;
        }
        public IActionResult IeltsExamList()
        {
            var data = ieltsExamQueryFacade.GetIeltsExamList();

            return View(data);
        }
        
        public IActionResult IeltsExamRegisterPage(Guid id)
        {
            try
            {
                ViewBag.IeltsExamId = id;
                var ieltsExam = ieltsExamQueryFacade.GetIeltsExamByIdForUserpanel(id);
                //var customerId = new System.Guid(userManager.GetUserId(User));

                //var placementUserScoreList = iPlacementUserScoreQueryFacade.GetPlacementUserScoreByCustomer(customerId, id);
                //if (placementUserScoreList != null)
                //    placementUserScoreList.ExamDate_Persian = DateConverter.MiladiToShamsiConvert(placementUserScoreList.ExamDate);

                //ViewBag.PlacementExamId = id;

                return View(ieltsExam);
            }
            catch (Exception e)
            {
                return RedirectToAction("ShowResultStatus", new { CompletionFlag = false,id=id });
            }
            
        }

        public ActionResult ShowResultStatus(bool CompletionFlag,Guid? id)
        {
            ViewBag.CompletionStatus = CompletionFlag;
            ViewBag.IeltsExamId = id;
            return View();
        }

        public async Task<IActionResult> IeltsExamRegisterPageFinal(Guid id)
        {
            try
            {
                ViewBag.IeltsExamId = id;
                ieltsId = id;

                var ieltsExam = ieltsExamQueryFacade.GetIeltsExamByIdForUserpanel(id);
                var customerId = new System.Guid(userManager.GetUserId(User));

                AddIeltsExamParticipantsCommand addIeltsExamParticipantsCommand = new AddIeltsExamParticipantsCommand();
                addIeltsExamParticipantsCommand.IeltsExamId = id;
                addIeltsExamParticipantsCommand.IeltsExamOrederNumber = 11;
                addIeltsExamParticipantsCommand.IeltsExamPriceId = ieltsExam.IeltsExamPriceId;
                addIeltsExamParticipantsCommand.RegisterDate = DateTime.Now;
                addIeltsExamParticipantsCommand.CustomerId = customerId;
                addIeltsExamParticipantsCommand.IeltsExamParticipantsStatusId = ExamParticipantsStatusList.PreRegister;

                IeltsExamParticipantsDetailDto ieltsExamParticipantsDetailDto = new IeltsExamParticipantsDetailDto();
                ieltsExamParticipantsDetailDto.ListeningExamId = ieltsExam.ListeningExamId;
                ieltsExamParticipantsDetailDto.ReadingExamId = ieltsExam.ReadingExamId;
                ieltsExamParticipantsDetailDto.WritingExamId = ieltsExam.WritingExamId;
                ieltsExamParticipantsDetailDto.SpeakingExamId = ieltsExam.SpeakigExamId;

                addIeltsExamParticipantsCommand.ieltsExamParticipantsDetailDto = ieltsExamParticipantsDetailDto;

                participantsId = iIeltsExamParticipantsFacade.AddIeltsExamParticipants(addIeltsExamParticipantsCommand);

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
                long? price = ieltsExam.PriceAmount - ((ieltsExam.PriceAmount / 100) * ieltsExam.DiscontentAmount);
                //**
                //**********************
                Guid bankTransactionTypeId = BankTransactionTypeList.SendToBank;
                Guid examTypeId = ExamTypeList.IeltsExam;
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
                ModelState.AddModelError("IeltsExamRegisterException", e.Message);
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
                //        UpdatePayment(ieltsExamParticipantsId);
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
            Guid participantsId, 
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
                addBankTransactionCommand.ParticipantsId = participantsId;
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

        private int UpdatePayment(Guid participantsId, string bankTransactionCode, Guid bankTransactionTypeId)
        {
            int paymentId = 0;
            try
            {
                Guid customerId = new System.Guid(userManager.GetUserId(User));

                UpdateIeltsExamParticipantsCommand updateIeltsExamParticipantsCommand = new UpdateIeltsExamParticipantsCommand();
                updateIeltsExamParticipantsCommand.Id = participantsId;
                updateIeltsExamParticipantsCommand.IeltsExamParticipantsStatusId = ExamParticipantsStatusList.FinalRegister;

                iIeltsExamParticipantsFacade.UpdateIeltsExamParticipants(updateIeltsExamParticipantsCommand);


                UpdateBankTransactionByParticipantsIdCommand updateBankTransactionByParticipantsIdCommand = new UpdateBankTransactionByParticipantsIdCommand();
                updateBankTransactionByParticipantsIdCommand.ParticipantsId = participantsId;
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



    }
}
