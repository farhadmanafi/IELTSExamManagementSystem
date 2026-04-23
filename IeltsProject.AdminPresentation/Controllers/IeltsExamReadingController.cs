using ExamContext.Reading.Aplication.Contracts.ReadingExamAggregate;
using ExamContext.Reading.Aplication.Contracts.ReadingQuestionAggregate;
using ExamContext.Reading.Facade.Contracts.ReadingExamAggregate;
using ExamContext.Reading.Facade.Contracts.ReadingQuestionAggregate;
using ExamContext.ReadModel.Queries.Contracts.ReadingContext;
using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingExamAggregate;
using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingExamAggregate.DataContracts;
using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingQuestionAggregate;
using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingQuestionAggregate.DataContracts;
using Framework.Mapper;
using Ielts.Common.GeneralClass;
using IeltsProject.AdminPresentation.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;

namespace IeltsProject.AdminPresentation.Controllers
{
    public class IeltsExamReadingController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IReadingExamSectionQueryFacade ReadingSectionQueryFacade;
        private readonly IReadingExamSectionCommandFacade ReadingExamSectionCommandFacade;
        private readonly IReadingExamQuestionBlockQueryFacade ReadingExamQuestionBlockQueryFacade;
        private readonly IReadingExamQuestionBlockCommandFacade ReadingExamQuestionBlockCommandFacade;
        private readonly IReadingQuestionQueryFacade ReadingQuestionQueryFacade;
        private readonly IReadingQuestionTypeQueryFacade ReadingQuestionTypeQueryFacade;
        private readonly IReadingQuestionCommandFacade ReadingQuestionCommandFacade;
        private readonly IReadingQuestionAnswersCommandFacade ReadingQuestionAnswersCommandFacade;
        private readonly IReadingQuestionAnswersQueryFacade ReadingQuestionAnswersQueryFacade;
        private readonly IReadingExamQueryFacade iReadingExamQueryFacade;
        private readonly IReadingExamCommandFacade iReadingExamCommandFacade;
        private readonly IWebHostEnvironment _root;
        public IeltsExamReadingController(UserManager<ApplicationUser> userManager,
                                   IReadingExamSectionQueryFacade ReadingSectionQueryFacade,
                                   IReadingExamSectionCommandFacade ReadingExamSectionCommandFacade,
                                   IReadingExamQuestionBlockQueryFacade ReadingExamQuestionBlockQueryFacade,
                                   IReadingExamQuestionBlockCommandFacade ReadingExamQuestionBlockCommandFacade,
                                   IReadingQuestionQueryFacade ReadingQuestionQueryFacade,
                                   IReadingQuestionTypeQueryFacade ReadingQuestionTypeQueryFacade,
                                   IReadingQuestionCommandFacade ReadingQuestionCommandFacade,
                                   IReadingQuestionAnswersCommandFacade ReadingQuestionAnswersCommandFacade,
                                   IReadingQuestionAnswersQueryFacade ReadingQuestionAnswersQueryFacade,
                                   IReadingExamQueryFacade iReadingExamQueryFacade,
                                   IReadingExamCommandFacade iReadingExamCommandFacade,
                                   IWebHostEnvironment root)
        {
            this.userManager = userManager;
            this.ReadingSectionQueryFacade = ReadingSectionQueryFacade;
            this.ReadingExamSectionCommandFacade = ReadingExamSectionCommandFacade;
            this.ReadingExamQuestionBlockQueryFacade = ReadingExamQuestionBlockQueryFacade;
            this.ReadingExamQuestionBlockCommandFacade = ReadingExamQuestionBlockCommandFacade;
            this.ReadingQuestionQueryFacade = ReadingQuestionQueryFacade;
            this.ReadingQuestionTypeQueryFacade = ReadingQuestionTypeQueryFacade;
            this.ReadingQuestionCommandFacade = ReadingQuestionCommandFacade;
            this.ReadingQuestionAnswersCommandFacade = ReadingQuestionAnswersCommandFacade;
            this.ReadingQuestionAnswersQueryFacade = ReadingQuestionAnswersQueryFacade;
            this.iReadingExamQueryFacade = iReadingExamQueryFacade;
            this.iReadingExamCommandFacade = iReadingExamCommandFacade;
            _root = root;
        }
        #region ReadingOperations
        public IActionResult IeltsReading_Load(Guid id)
        {
            var examCount = iReadingExamQueryFacade.GetReadingExamCount(id);
            if (examCount<1)
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
        public ActionResult IeltsReadingGridData(DataTableAjaxPostModel model, Guid id)
        {
            var ReadingExamSectionList = iReadingExamQueryFacade.GetReadingExamByFilteringList(ref model, id);

            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = ReadingExamSectionList
            });
        }
        public IActionResult AddIeltsReading_Load(Guid id)
        {
            ViewBag.HasError = false;
            ViewBag.IeltsExamId = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddIeltsReading(ReadingExamQueryFacadeDto model)
        {
            try
            {
                var command = new AddReadingExamCommand();
                command.Title = model.Title;
                command.IeltsExamId = model.IeltsExamId;
                command.Description = model.Description;
                command.TimerMinuties = model.TimerMinuties;
                command.IsActive = true;
                command.IsDeleted = false;

                iReadingExamCommandFacade.AddReadingExam(command);

                return RedirectToAction("IeltsReading_Load", new { Id = model.IeltsExamId });
            }
            catch (Exception e)
            {

                ModelState.AddModelError("AddIeltsReadingException", e.Message);
                ViewBag.HasError = true;
                ViewBag.IeltsExamId = model.IeltsExamId;
                return View("AddIeltsReading_Load", model);
            }
        }
        public IActionResult EditReadingExam_Load(Guid id)
        {
            ViewBag.HasError = false;
            var ReadingExamSection = iReadingExamQueryFacade.GetReadingExamById(id);
            return View(ReadingExamSection);
        }
        [HttpPost]
        public IActionResult EditReadingExam(ReadingExamQueryFacadeDto model)
        {
            try
            {
                var command = Mapper.Map<ReadingExamQueryFacadeDto, UpdateReadingExamCommand>(model);
                iReadingExamCommandFacade.UpdateReadingExam(command);

                return RedirectToAction("IeltsReading_Load", new { Id = model.IeltsExamId });
            }
            catch (Exception e)
            {
                ModelState.AddModelError("EditReadingExamException", e.Message);
                ViewBag.HasError = true;
                return View("EditReadingExam_Load", model);
            }
        }

        //-----------------------
        public IActionResult ReadingSection_Load(Guid id)
        {
            ViewBag.ReadingExamId = id;
            return View();
        }
        public ActionResult ReadingSectionListGridData(DataTableAjaxPostModel model, Guid id)
        {
            var ReadingExamSectionList = ReadingSectionQueryFacade.GetReadingExamSectionListForGridView(ref model, id);

            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = ReadingExamSectionList
            });
        }
        public IActionResult AddReadingSection_Load(Guid id)
        {
            ViewBag.HasError = false;
            ViewBag.ReadingExamId = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddReadingSection(ReadingExamSectionQueryFacadeDto model)
        {
            try
            {
                var command = new AddReadingExamSectionCommand();
                command.Title = model.Title;
                command.Description = model.Description;
                command.ReadingText = model.ReadingText;
                command.OrderNo = model.OrderNo;
                command.IsActive = true;
                command.IsDeleted = false;
                command.ReadingExamId = model.ReadingExamId;


                ReadingExamSectionCommandFacade.AddReadingExamSection(command);

                return RedirectToAction("ReadingSection_Load", new { id = model.ReadingExamId });
            }
            catch (Exception e)
            {

                ModelState.AddModelError("AddReadingSectionException", e.Message);
                ViewBag.HasError = true;
                ViewBag.ReadingExamId = model.ReadingExamId;
                return View("AddReadingSection_Load", model);
            }
        }
        public IActionResult EditReadingExamSection_Load(Guid id)
        {
            ViewBag.HasError = false;
            var ReadingExamSection = ReadingSectionQueryFacade.GetReadingExamSection(id);
            return View(ReadingExamSection);
        }
        [HttpPost]
        public IActionResult EditReadingExamSection(ReadingExamSectionQueryFacadeDto model)
        {
            try
            {
                var command = Mapper.Map<ReadingExamSectionQueryFacadeDto, UpdateReadingExamSectionCommand>(model);
                ReadingExamSectionCommandFacade.UpdateReadingExamSection(command);

                return RedirectToAction("ReadingSection_Load", new { id = model.ReadingExamId });
            }
            catch (Exception e)
            {

                ModelState.AddModelError("EditReadingExamSectionException", e.Message);
                ViewBag.HasError = true;
                return View("EditReadingExamSection_Load", model);
            }
        }

        public IActionResult ReadingExamText_Load(Guid id)
        {
            var readingExamReadingText = ReadingSectionQueryFacade.GetReadingExamSection(id)?.ReadingText;
            if (!string.IsNullOrWhiteSpace(readingExamReadingText))
            {
            ViewBag.ReadingText = readingExamReadingText;
            }
            return View();
        }
        [HttpPost]
        [Route("file-upload")]
        public IActionResult UploadImage(IFormFile upload)
        {
            if (upload.Length <= 0) return null;
            // < 256 Kb
            if (upload.Length >= 262144) return null;

            var filename = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();
            var path = Path.Combine(_root.WebRootPath, "imageforcontent", filename);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                upload.CopyTo(stream);
            }
            var url = $"{"https://adminpanel.bpvielts.com/imageforcontent/"}{filename}";
            return Json(new { uploaded = true, url });
        }
        //-----------------------
        public IActionResult ReadingQuestionBlock_Load(Guid id)
        {
            ViewBag.ReadingExamSectionId = id;
            return View();
        }
        public IActionResult ReadingQuestionBlockListGridData(DataTableAjaxPostModel model, Guid id)
        {
            var ReadingExamQuestionBlockList = ReadingExamQuestionBlockQueryFacade.GetReadingExamQuestionBlockListForGridView(ref model, id);

            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = ReadingExamQuestionBlockList
            });
        }
        public IActionResult AddReadingQuestionBlock_Load(Guid id)
        {
            ViewBag.HasError = false;
            ViewBag.ReadingExamSectionId = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddReadingQuestionBlock(ReadingExamQuestionBlockQueryFacadeDto model)
        {
            try
            {
                var command = new AddReadingExamQuestionBlockCommand();
                command.Title = model.Title;
                command.OrderNo = model.OrderNo;
                command.Description = model.Description;
                command.ReadingExamSectionId = model.ReadingExamSectionId;
                command.IsActive = true;
                command.IsDeleted = false;

                ReadingExamQuestionBlockCommandFacade.AddReadingExamQuestionBlock(command);

                return RedirectToAction("ReadingQuestionBlock_Load", new { id = model.ReadingExamSectionId });
            }
            catch (Exception e)
            {

                ModelState.AddModelError("AddReadingQuestionBlockException", e.Message);
                ViewBag.HasError = true;
                ViewBag.ReadingExamSectionId = model.ReadingExamSectionId;
                return View("AddReadingQuestionBlock_Load", model);
            }
        }
        public IActionResult EditReadingExamQuestionBlock_Load(Guid id)
        {
            ViewBag.HasError = false;
            var ReadingExamQuestionBlock = ReadingExamQuestionBlockQueryFacade.GetReadingExamQuestionBlock(id);
            return View(ReadingExamQuestionBlock);
        }
        [HttpPost]
        public IActionResult EditReadingExamQuestionBlock(ReadingExamQuestionBlockQueryFacadeDto model)
        {
            try
            {
                var command = Mapper.Map<ReadingExamQuestionBlockQueryFacadeDto, UpdateReadingExamQuestionBlockCommand>(model);
                ReadingExamQuestionBlockCommandFacade.UpdateReadingExamQuestionBlock(command);

                return RedirectToAction("ReadingQuestionBlock_Load", new { id = model.ReadingExamSectionId });
            }
            catch (Exception e)
            {

                ModelState.AddModelError("EditReadingExamQuestionBlockException", e.Message);
                ViewBag.HasError = true;
                return View("EditReadingExamQuestionBlock_Load", model);
            }
        }
        //-----------------------
        public IActionResult ReadingQuestionList(Guid id)
        {
            ViewBag.ReadingExamId = id;
            return View();
        }
        public IActionResult ReadingQuestionListGridData(DataTableAjaxPostModel model, Guid id)
        {
            var ReadingQuestionList = ReadingQuestionQueryFacade.GetReadingQuestionListForGridView(ref model, id);

            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = ReadingQuestionList
            });
        }
        public IActionResult AddReadingQuestion_Load(Guid id, bool? hasError = false, string errorMessage = "")
        {
            ViewBag.HasError = hasError;
            ModelState.AddModelError("AddReadingQuestionException", errorMessage);
            ViewBag.ReadingExamId = id;
            var ReadingQuestionTypeList = ReadingQuestionTypeQueryFacade.GetReadingQuestionTypeList();
            ViewBag.ReadingQuestionTypeList = new SelectList(ReadingQuestionTypeList, "Id", "Title");

            var ReadingExamSectionList = ReadingSectionQueryFacade.GetReadingExamSectionListByReadingExamId(id);
            ViewBag.ReadingExamSectionList = new SelectList(ReadingExamSectionList, "Id", "Title");

            return View();
        }
        [HttpPost]
        public IActionResult AddReadingQuestion(ReadingQuestionQueryFacadeDto model)
        {
            try
            {
                var command = new AddReadingQuestionCommand();
                command.Title = model.Title;
                command.Description = model.Description;
                command.ReadingExamId = model.ReadingExamId;//TODO IMPORTANT! Exam Id should be added to all questions and mappings
                command.OrderNo = model.OrderNo;
                command.ReadingQuestionTypeId = model.ReadingQuestionTypeId;
                command.ReadingExamSectionId = model.ReadingExamSectionId;
                command.ReadingExamQuestionBlockId = model.ReadingExamQuestionBlockId;
                command.IsActive = model.IsActive;
                command.IsDeleted = false;

                ReadingQuestionCommandFacade.AddReadingQuestion(command);

                return RedirectToAction("ReadingQuestionList", new { Id = model.ReadingExamId });
            }
            catch (Exception e)
            {

                return RedirectToAction("AddReadingQuestion_Load", new { id = model.ReadingExamId, hasError = true, errorMessage = e.Message });
            }
        }
        public IActionResult EditReadingQuestion_Load(Guid id, bool? hasError = false, string errorMessage = "")
        {
            ViewBag.HasError = hasError;
            ModelState.AddModelError("EditReadingQuestionException", errorMessage);
            var data = ReadingQuestionQueryFacade.GetReadingQuestion(id);

            var ReadingQuestionTypeList = ReadingQuestionTypeQueryFacade.GetReadingQuestionTypeList();
            ViewBag.ReadingQuestionTypeList = new SelectList(ReadingQuestionTypeList, "Id", "Title", data.ReadingQuestionTypeId);

            var ReadingExamSectionList = ReadingSectionQueryFacade.GetReadingExamSectionListByReadingExamId(data.ReadingExamId);
            ViewBag.ReadingExamSectionList = new SelectList(ReadingExamSectionList, "Id", "Title", data.ReadingExamSectionId);

            var ReadingExamQuestionBlocList = ReadingExamQuestionBlockQueryFacade.GetReadingExamQuestionBlocListByReadingSectionId(data.ReadingExamSectionId);
            ViewBag.ReadingExamQuestionBlocList = new SelectList(ReadingExamQuestionBlocList, "Id", "Title", data.ReadingExamQuestionBlockId);

            return View(data);
        }
        [HttpPost]
        public IActionResult EditReadingQuestion(ReadingQuestionQueryFacadeDto model)
        {
            try
            {
                var command = Mapper.Map<ReadingQuestionQueryFacadeDto, UpdateReadingQuestionCommand>(model);
                ReadingQuestionCommandFacade.UpdateReadingQuestion(command);

                return RedirectToAction("ReadingQuestionList", new { Id = model.ReadingExamId });
            }
            catch (Exception e)
            {

                return RedirectToAction("EditReadingQuestion_Load", new { id = model.Id, hasError = true, errorMessage = e.Message });
            }
        }

        [HttpPost]
        public JsonResult GetReadingExamQuestionBlocListByReadingSectionId(Guid ReadingExamSectionId)
        {
            var ReadingExamQuestionBlocList = ReadingExamQuestionBlockQueryFacade.GetReadingExamQuestionBlocListByReadingSectionId(ReadingExamSectionId);
            var ReadingExamQuestionBlocLists = new SelectList(ReadingExamQuestionBlocList, "Id", "Title");

            return Json(ReadingExamQuestionBlocLists);
        }
        //-----------------------
        public IActionResult ReadingQuestionAnswerList(Guid id)
        {
            ViewBag.ReadingQuestionId = id;
            return View();
        }
        public IActionResult ReadingQuestionAnswerListGridData(DataTableAjaxPostModel model, Guid id)
        {
            var ReadingQuestionAnswerList = ReadingQuestionAnswersQueryFacade.GetReadingQuestionAnswerListForGridView(ref model, id);

            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = ReadingQuestionAnswerList
            });

        }
        public IActionResult AddReadingQuestionAnswer_Load(System.Guid id, bool? hasError = false, string errorMessage = "")
        {
            ViewBag.HasError = hasError;
            ModelState.AddModelError("AddReadingQuestionAnswerException", errorMessage);
            ViewBag.ReadingQuestionId = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddReadingQuestionAnswer(ReadingQuestionAnswersQueryFacadeDto model)
        {
            try
            {
                var command = new AddReadingQuestionAnswersCommand();
                command.Title = model.Title;
                command.Description = model.Description;
                command.ReadingQuestionId = model.ReadingQuestionId;
                command.OrderNo = model.OrderNo;
                command.IsCorrect = model.IsCorrect;
                command.IsActive = model.IsActive;
                command.IsDeleted = false;

                ReadingQuestionAnswersCommandFacade.AddReadingQuestionAnswers(command);

                return RedirectToAction("ReadingQuestionAnswerList", new { id = model.ReadingQuestionId });
            }
            catch (Exception e)
            {

                return RedirectToAction("AddReadingQuestionAnswer_Load", new { id = model.ReadingQuestionId, hasError = true, errorMessage = e.Message });
            }
        }
        public IActionResult EditReadingQuestionAnswer_Load(Guid id, bool? hasError = false, string errorMessage = "")
        {
            var data = ReadingQuestionAnswersQueryFacade.GetReadingQuestionAnswers(id);
            ViewBag.HasError = hasError;
            ModelState.AddModelError("EditReadingQuestionAnswerException", errorMessage);

            return View(data);

        }
        [HttpPost]
        public IActionResult EditReadingQuestionAnswer(ReadingQuestionAnswersQueryFacadeDto model)
        {
            try
            {
                var command = Mapper.Map<ReadingQuestionAnswersQueryFacadeDto, UpdateReadingQuestionAnswersCommand>(model);
                ReadingQuestionAnswersCommandFacade.UpdateReadingQuestionAnswers(command);

                return RedirectToAction("ReadingQuestionAnswerList", new { id = model.ReadingQuestionId });
            }
            catch (Exception e)
            {

                return RedirectToAction("EditReadingQuestionAnswer_Load", new { id = model.Id, hasError = true, errorMessage = e.Message });
            }
        }
        #endregion
    }
}
