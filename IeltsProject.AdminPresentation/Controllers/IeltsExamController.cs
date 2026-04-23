using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ielts.Common.GeneralClass;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.IeltsAggregarte.IeltsAggregarte;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.IeltsAggregarte.DataContracts;
using ExamContext.Ielts.Facade.Contracts.IeltsAggregarte;
using ExamContext.Ielts.Aplication.Contracts.IeltsAggregarte;
using Microsoft.AspNetCore.Identity;
using IeltsProject.AdminPresentation.Models;
using Framework.Mapper;
using ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningExamAggregate;
using ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningExamAggregate.DataContracts;
using ExamContext.Listening.Aplication.Contracts.ListeningExamAggregate;
using ExamContext.Listening.Facade.Contracts.ListeningExamAggregate;
using ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningQuestionAggregate;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningQuestionAggregate.DataContracts;
using ExamContext.Listening.Aplication.Contracts.ListeningQuestionAggregate;
using ExamContext.Listening.Facade.Contracts.ListeningQuestionAggregate;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.IeltsAggregarte;

namespace IeltsProject.AdminPresentation.Controllers
{
    [Authorize(Roles = "Admin")]
    public class IeltsExamController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IIeltsExamQueryFacade ieltsExamQueryFacade;
        private readonly IIeltsExamCommandFacade ieltsExamCommandFacade;
        private readonly IIeltsExamPriceQueryFacade iieltsExamPriceQueryFacade;
        private readonly IIeltsExamPriceCommandFacade iieltsExamPriceCommandFacade;
        public IeltsExamController(UserManager<ApplicationUser> userManager,
                                   IIeltsExamQueryFacade ieltsExamQueryFacade,
                                   IIeltsExamCommandFacade ieltsExamCommandFacade,
                                   IIeltsExamPriceQueryFacade iieltsExamPriceQueryFacade,
                                   IIeltsExamPriceCommandFacade iieltsExamPriceCommandFacade)
        {
            this.userManager = userManager;
            this.ieltsExamQueryFacade = ieltsExamQueryFacade;
            this.ieltsExamCommandFacade = ieltsExamCommandFacade;
            this.iieltsExamPriceQueryFacade = iieltsExamPriceQueryFacade;
            this.iieltsExamPriceCommandFacade = iieltsExamPriceCommandFacade;
        }

        #region ExamList
        public IActionResult ExamList()
        {
            return View();
        }

        public ActionResult ExamListData(DataTableAjaxPostModel model)
        {
            var ieltsExamList = ieltsExamQueryFacade.GetIeltsExamFilteringList(ref model);

            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = ieltsExamList
            });
        }

        #endregion

        #region IeltsExamOpertions
        public IActionResult AddIeltsExam_Load()
        {
            ViewBag.HasError = false;
            return View();
        }
        [HttpPost]
        public IActionResult AddIeltsExam(IeltsExamQueryFacadeDto model)
        {
            try
            {
                var command = new AddIeltsExamCommand();
                command.Title = model.Title;
                command.Description = model.Description;
                command.ActivedDate = DateConverter.ShamsiToMiladiConvert(model.ActivedDate_Persian);
                command.DeactivedDate = DateConverter.ShamsiToMiladiConvert(model.DeActivedDate_Persian);
                command.UserId = new System.Guid(userManager.GetUserId(User));//TODO : Add Customer Id
                command.IsActive = model.IsActive;
                command.IsDeleted = false;

                ieltsExamCommandFacade.AddIeltsExam(command);

                return RedirectToAction("ExamList");
            }
            catch (Exception e)
            {

                ModelState.AddModelError("AddIeltsExamException", e.Message);
                ViewBag.HasError = true;
                return View("AddIeltsExam_Load", model);
            }
        }
        public IActionResult EditIeltsExam_Load(Guid id, bool? hasError = false, string errorMessage = "")
        {
            ViewBag.HasError = hasError;
            ModelState.AddModelError("EditIeltsExamException", errorMessage);
            var data = ieltsExamQueryFacade.GetIeltsExamById(id);
            data.ActivedDate_Persian = DateConverter.MiladiToShamsiConvert(data.ActivedDate);
            data.DeActivedDate_Persian = DateConverter.MiladiToShamsiConvert(data.DeActivedDate);
            return View(data);
        }
        [HttpPost]
        public IActionResult EditIeltsExam(IeltsExamQueryFacadeDto model)
        {
            try
            {
                model.ActivedDate = DateConverter.ShamsiToMiladiConvert(model.ActivedDate_Persian);
                model.DeActivedDate = DateConverter.ShamsiToMiladiConvert(model.DeActivedDate_Persian);
                var command = Mapper.Map<IeltsExamQueryFacadeDto, UpdateIeltsExamCommand>(model);
                ieltsExamCommandFacade.UpdateIeltsExam(command);

                return RedirectToAction("ExamList");
            }
            catch (Exception e)
            {

                return RedirectToAction("EditIeltsExam_Load", new { id = model.Id, hasError = true, errorMessage = e.Message });
            }
        }
        public IActionResult IeltsUserScoreList(Guid id) //TODO differen from online placement should be develop and scores of each 5 exam should be displaied separatly
        {
            return View();
        }
        #endregion

        #region ExamPrice
        public IActionResult IeltsExamPrice_Load(Guid id)
        {
            ViewBag.IeltsExamId = id;
            return View();
        }
        public ActionResult ExamPriceListData(DataTableAjaxPostModel model,Guid id)
        {
            var ieltsExamList = iieltsExamPriceQueryFacade.GetIeltsExamPriceFilteringList(ref model,id);

            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = ieltsExamList
            });
        }

        public IActionResult AddIeltsExamPrice_Load(Guid id)
        {
            ViewBag.HasError = false;
            ViewBag.IeltsExamId = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddIeltsExamPrice(IeltsExamPriceQueryFacadeDto model)
        {
            try
            {
                var command = new AddIeltsExamPriceCommand();
                command.PriceAmount = model.PriceAmount;
                command.IeltsExamId = model.IeltsExamId;
                command.DiscontentAmount = model.DiscontentAmount;
                command.ActivedDate = DateTime.Now;
                //command.DeactivedDate = DateConverter.ShamsiToMiladiConvert(model.DeActivedDate_Persian); ;
                command.IsActive = true;
                command.IsDeleted = false;

                iieltsExamPriceCommandFacade.AddIeltsExamPrice(command);

                return RedirectToAction("IeltsExamPrice_Load", new { Id = model.IeltsExamId });
            }
            catch (Exception e)
            {

                ModelState.AddModelError(" AddIeltsExamPriceException", e.Message);
                ViewBag.HasError = true;
                ViewBag.IeltsExamId = model.IeltsExamId;
                return View("AddIeltsExamPrice_Load", model);
            }
           
        }

        #endregion



    }
}
