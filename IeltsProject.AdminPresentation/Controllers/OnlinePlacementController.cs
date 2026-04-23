using ExamContext.OnlinePlacement.Aplication.Contracts.PlacementExamAggregate;
using ExamContext.OnlinePlacement.Aplication.Contracts.PlacementQuestionAggregate;
using ExamContext.OnlinePlacement.Facade.Contracts.PlacementExamAggregate;
using ExamContext.OnlinePlacement.Facade.Contracts.PlacementQuestionAggregate;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.IeltsAggregarte;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementExamAggregate;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementExamAggregate.DataContracts;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementQuestionAggregate;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementQuestionAggregate.DataContracts;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementUserAnswerAggregate;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementUserScoreAggregate;
using Framework.Mapper;
using Ielts.Common.GeneralClass;
using IeltsProject.AdminPresentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace IeltsProject.AdminPresentation.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OnlinePlacementController : Controller
    {        
        private readonly IPlacementExamQueryFacade iPlacementExamQueryFacade;
        private readonly IPlacementExamFacade iPlacementExamFacade;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPlacementQuestionQueryFacade iPlacementQuestionQueryFacade;
        private readonly IPlacementQuestionTypeQueryFacade iPlacementQuestionTypeQueryFacade;
        private readonly IPlacementQuestionFacade iPlacementQuestionFacade;
        private readonly IPlacementQuestionAnswersQueryFacade iPlacementQuestionAnswersQueryFacade;
        private readonly IPlacementQuestionAnswersFacade iPlacementQuestionAnswersFacade;
        private readonly IPlacementUserScoreQueryFacade iPlacementUserScoreQueryFacade;
        private readonly IPlacementUserAnswerQueryFacade iPlacementUserAnswerQueryFacade;
        private readonly IPlacementExamPriceQueryFacade iPlacementExamPriceQueryFacade;
        private readonly IPlacementExamPriceFacade iPlacementExamPriceFacade;

        public OnlinePlacementController(IPlacementExamQueryFacade iPlacementExamQueryFacade,
            UserManager<ApplicationUser> userManager,
            IPlacementExamFacade iPlacementExamFacade,
            IPlacementQuestionQueryFacade iPlacementQuestionQueryFacade,
            IPlacementQuestionTypeQueryFacade iPlacementQuestionTypeQueryFacade,
            IPlacementQuestionFacade iPlacementQuestionFacade,
            IPlacementQuestionAnswersQueryFacade iPlacementQuestionAnswersQueryFacade,
            IPlacementQuestionAnswersFacade iPlacementQuestionAnswersFacade,
            IPlacementUserScoreQueryFacade iPlacementUserScoreQueryFacade,
            IPlacementUserAnswerQueryFacade iPlacementUserAnswerQueryFacade,
            IPlacementExamPriceQueryFacade iPlacementExamPriceQueryFacade,
            IPlacementExamPriceFacade iPlacementExamPriceFacade)
        {
            this.iPlacementExamQueryFacade = iPlacementExamQueryFacade;
            this.userManager = userManager;
            this.iPlacementExamFacade = iPlacementExamFacade;
            this.iPlacementQuestionQueryFacade = iPlacementQuestionQueryFacade;
            this.iPlacementQuestionTypeQueryFacade = iPlacementQuestionTypeQueryFacade;
            this.iPlacementQuestionFacade = iPlacementQuestionFacade;
            this.iPlacementQuestionAnswersQueryFacade = iPlacementQuestionAnswersQueryFacade;
            this.iPlacementQuestionAnswersFacade = iPlacementQuestionAnswersFacade;
            this.iPlacementUserScoreQueryFacade = iPlacementUserScoreQueryFacade;
            this.iPlacementUserAnswerQueryFacade = iPlacementUserAnswerQueryFacade;
            this.iPlacementExamPriceQueryFacade = iPlacementExamPriceQueryFacade;
            this.iPlacementExamPriceFacade = iPlacementExamPriceFacade;
        }

        #region ExamList
        public IActionResult ExamList()
        {
            return View();
        }

        public ActionResult ExamListData(DataTableAjaxPostModel model)
        {
            var placementExamList = iPlacementExamQueryFacade.GetPlacementExamList(ref model);

            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = placementExamList
            });
        }

        public IActionResult ExamResualts()
        {
            return View();
        }

        public IActionResult AddPlacementExam_Load()
        {
            ViewBag.HasError = false;
            return View();
        }
        [HttpPost]
        public IActionResult AddPlacementExam(PlacementExamQueryFacadeDto model)
        {
            try
            {
                var command = new AddPlacementExamCommand();
                command.Title = model.Title;
                command.Description = model.Description;
                command.ActivedDate = DateConverter.ShamsiToMiladiConvert(model.ActivedDate_Persian);
                command.DeActivedDate = DateConverter.ShamsiToMiladiConvert(model.DeActivedDate_Persian);
                command.CustomerId = new System.Guid(userManager.GetUserId(User));
                command.IsActive = model.IsActive;
                command.IsDeleted = false;

                iPlacementExamFacade.AddPlacementExam(command);

                return RedirectToAction("ExamList");
            }
            catch (Exception e)
            {

                ModelState.AddModelError("AddPlacementExamException", e.Message);
                ViewBag.HasError = true;
                return View("AddPlacementExam_Load", model);
            }
        }

        public IActionResult EditOnlinePlacement_Load(Guid id, bool? hasError = false, string errorMessage = "")
        {
            ViewBag.HasError = hasError;
            ModelState.AddModelError("EditOnlinePlacementException", errorMessage);
            var data = iPlacementExamQueryFacade.GetPlacementExam(id);
            data.ActivedDate_Persian = DateConverter.MiladiToShamsiConvert(data.ActivedDate);
            data.DeActivedDate_Persian = DateConverter.MiladiToShamsiConvert(data.DeActivedDate);

            return View(data);
        }

        [HttpPost]
        public IActionResult EditOnlinePlacement(PlacementExamQueryFacadeDto model)
        {
            try
            {
                model.ActivedDate = DateConverter.ShamsiToMiladiConvert(model.ActivedDate_Persian);
                model.DeActivedDate = DateConverter.ShamsiToMiladiConvert(model.DeActivedDate_Persian);
                var command = Mapper.Map<PlacementExamQueryFacadeDto, UpdatePlacementExamCommand>(model);
                iPlacementExamFacade.UpdatePlacementExam(command);

                return RedirectToAction("ExamList");
            }
            catch (Exception e)
            {
                return RedirectToAction("EditOnlinePlacement_Load", new { id = model.Id, hasError = true, errorMessage = e.Message });
            }
            
        }

        #endregion


        #region OnlinePlacementQuestionList
        public IActionResult OnlinePlacementQuestionList(Guid id)
        {
            ViewBag.PlacementExamtId = id;
            return View();
        }

        public ActionResult OnlinePlacementQuestionListData(DataTableAjaxPostModel model, Guid id)
        {
            var placementExamList = iPlacementQuestionQueryFacade.GetPlacementQuestionList(ref model,id);

            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = placementExamList
            });
        }

        public IActionResult AddOnlinePlacementQuestion_Load(Guid id, bool? hasError = false, string errorMessage = "")
        {
            ViewBag.HasError = hasError;
            ModelState.AddModelError("AddOnlinePlacementQuestionException", errorMessage);
            ViewBag.PlacementExamtId = id;
            var placementQuestionTypeList = iPlacementQuestionTypeQueryFacade.GetPlacementQuestionTypeList();
            ViewBag.PlacementQuestionTypeList = new SelectList(placementQuestionTypeList, "Id", "Title");
            return View();
        }
        [HttpPost]
        public IActionResult AddOnlinePlacementQuestion(PlacementQuestionQueryFacadeDto model)
        {
            try
            {
                var command = new AddPlacementQuestionCommand();
                command.Title = model.Title;
                command.Description = model.Description;
                command.PlacementExamtId = model.PlacementExamtId;
                command.OrderNo = model.OrderNo;
                command.PlacementQuestionTypeId = model.PlacementQuestionTypeId;
                command.CustomerId = new System.Guid(userManager.GetUserId(User));
                command.IsActive = model.IsActive;
                command.IsDeleted = false;

                iPlacementQuestionFacade.AddPlacementQuestion(command);

                return RedirectToAction("OnlinePlacementQuestionList", new { Id = model.PlacementExamtId });
            }
            catch (Exception e)
            {

                return RedirectToAction("AddOnlinePlacementQuestion_Load", new { id = model.PlacementExamtId, hasError = true, errorMessage = e.Message });
            }
        }

        public IActionResult EditOnlinePlacementQuestion_Load(Guid id, bool? hasError = false, string errorMessage = "")
        {
            ViewBag.HasError = hasError;
            ModelState.AddModelError("EditOnlinePlacementQuestionException", errorMessage);

            var data = iPlacementQuestionQueryFacade.GetPlacementQuestion(id);
            var placementQuestionTypeList = iPlacementQuestionTypeQueryFacade.GetPlacementQuestionTypeList();
            ViewBag.PlacementQuestionTypeList = new SelectList(placementQuestionTypeList, "Id", "Title", data.PlacementQuestionTypeId);

            return View(data);
        }

        [HttpPost]
        public IActionResult EditOnlinePlacementQuestion(PlacementQuestionQueryFacadeDto model)
        {
            try
            {
                var command = Mapper.Map<PlacementQuestionQueryFacadeDto, UpdatePlacementQuestionCommand>(model);
                iPlacementQuestionFacade.UpdatePlacementQuestion(command);

                return RedirectToAction("OnlinePlacementQuestionList", new { Id = model.PlacementExamtId });
            }
            catch (Exception e)
            {

                return RedirectToAction("EditOnlinePlacementQuestion_Load", new { id = model.Id, hasError = true, errorMessage = e.Message });
            }
        }
        #endregion


        #region OnlinePlacementQuestionAnswerList
        public IActionResult OnlinePlacementQuestionAnswerList(Guid id)
        {
            ViewBag.PlacementQuestionId = id;
            return View();
        }

        public ActionResult OnlinePlacementQuestionAnswerListData(DataTableAjaxPostModel model, Guid id)
        {
            var placementExamList = iPlacementQuestionAnswersQueryFacade.GetPlacementQuestionAnswersList(ref model, id);

            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = placementExamList
            });
        }

        public IActionResult AddOnlinePlacementQuestionAnswer_Load(Guid id)
        {
            ViewBag.HasError = false;
            ViewBag.PlacementQuestionId = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddOnlinePlacementQuestionAnswer(PlacementQuestionAnswersQueryFacadeDto model)
        {
            try
            {
                var command = new AddPlacementQuestionAnswersCommand();
                command.Title = model.Title;
                command.Description = model.Description;
                command.PlacementQuestionId = model.PlacementQuestionId;
                command.CustomerId = new System.Guid(userManager.GetUserId(User));
                command.OrderNo = model.OrderNo;
                command.IsCorrect = model.IsCorrect;
                command.IsActive = model.IsActive;
                command.IsDeleted = false;

                iPlacementQuestionAnswersFacade.AddPlacementQuestionAnswers(command);

                return RedirectToAction("OnlinePlacementQuestionAnswerList", new { Id = model.PlacementQuestionId });
            }
            catch (Exception e)
            {

                ModelState.AddModelError("AddOnlinePlacementQuestionAnswerException", e.Message);
                ViewBag.HasError = true;
                ViewBag.PlacementQuestionId = model.PlacementQuestionId;
                return View("AddOnlinePlacementQuestionAnswer_Load", model);
            }
        }

        public IActionResult EditOnlinePlacementQuestionAnswer_Load(Guid id)
        {
            ViewBag.HasError = false;
            var data = iPlacementQuestionAnswersQueryFacade.GetPlacementQuestionAnswers(id);

            return View(data);
        }

        [HttpPost]
        public IActionResult EditOnlinePlacementQuestionAnswer(PlacementQuestionAnswersQueryFacadeDto model)
        {
            try
            {
                var command = Mapper.Map<PlacementQuestionAnswersQueryFacadeDto, UpdatePlacementQuestionAnswersCommand>(model);
                iPlacementQuestionAnswersFacade.UpdatePlacementQuestionAnswers(command);

                return RedirectToAction("OnlinePlacementQuestionAnswerList", new { Id = model.PlacementQuestionId });
            }
            catch (Exception e)
            {

                ModelState.AddModelError("EditOnlinePlacementQuestionAnswerException", e.Message);
                ViewBag.HasError = true;
                return View("EditOnlinePlacementQuestionAnswer_Load", model);
            }
        }
        #endregion

        #region PlacementUserScoreList
        public IActionResult PlacementUserScoreList(Guid id)
        {
            ViewBag.OnlinePlacemenId = id;
            return View();
        }

        public ActionResult PlacementUserScoreData(DataTableAjaxPostModel model, Guid id)
        {
            var placementUserScoreList = iPlacementUserScoreQueryFacade.GetPlacementUserScoreByIdList(ref model, id);

            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = placementUserScoreList
            });
        }
        #endregion

        #region OnlinePlacementUserScoreDetail
        public IActionResult OnlinePlacementUserScoreDetail(Guid id)
        {
            ViewBag.PlacementUserScoreId = id;
            return View();
        }

        public ActionResult OnlinePlacementUserScoreDetailData(DataTableAjaxPostModel model, Guid id)
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

        #region ExamPrice
        public IActionResult PlacementExamPrice_Load(Guid id)
        {
            ViewBag.IeltsExamId = id;
            return View();
        }
        public ActionResult ExamPriceListData(DataTableAjaxPostModel model, Guid id)
        {
            var ieltsExamList = iPlacementExamPriceQueryFacade.GetPlacementExamPriceFilteringList(ref model, id);

            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = ieltsExamList
            });
        }

        public IActionResult AddPlacementExamPrice_Load(Guid id)
        {
            ViewBag.HasError = false;
            ViewBag.PlacementExamId = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddPlacementExamPrice(PlacementExamPriceQueryFacadeDto model)
        {
            try
            {
                var command = new AddPlacementExamPriceCommand();
                command.PriceAmount = model.PriceAmount;
                command.PlacementExamId = model.PlacementExamId;
                command.DiscontentAmount = model.DiscontentAmount;
                command.ActivedDate = DateTime.Now;
                //command.DeactivedDate = DateConverter.ShamsiToMiladiConvert(model.DeActivedDate_Persian); ;
                command.IsActive = true;
                command.IsDeleted = false;

                iPlacementExamPriceFacade.AddPlacementExamPrice(command);

                return RedirectToAction("PlacementExamPrice_Load", new { Id = model.PlacementExamId });
            }
            catch (Exception e)
            {

                ModelState.AddModelError("AddPlacementExamPriceException", e.Message);
                ViewBag.HasError = true;
                ViewBag.IeltsExamId = model.PlacementExamId;
                return View("AddPlacementExamPrice_Load", model);
            }

        }

        #endregion


    }
}
