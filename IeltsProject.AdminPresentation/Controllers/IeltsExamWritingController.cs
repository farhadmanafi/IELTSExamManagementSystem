using ExamContext.ReadModel.Queries.Contracts.WritingContext.WritingExamAggregate;
using ExamContext.ReadModel.Queries.Contracts.WritingContext.WritingExamAggregate.DataContracts;
using ExamContext.Writing.Aplication.Contracts.WritingExamAggregate;
using ExamContext.Writing.Facade.Contracts.WritingExamAggregate;
using Framework.Mapper;
using Ielts.Common.GeneralClass;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace IeltsProject.AdminPresentation.Controllers
{
    public class IeltsExamWritingController : Controller
    {
        private readonly IWritingExamQueryFacade iWritingExamQueryFacade;
        private readonly IWritingExamCommandFacade iWritingExamCommandFacade;
        private readonly IWritingExamSectionQueryFacade iwritingExamSectionQueryFacade;
        private readonly IWritingExamSectionCommandFacade iwritingExamSectionCommandFacade;
        private readonly IWebHostEnvironment _root;
        public IeltsExamWritingController(IWritingExamQueryFacade iWritingExamQueryFacade,
                                          IWritingExamCommandFacade iWritingExamCommandFacade,
                                          IWritingExamSectionQueryFacade iwritingExamSectionQueryFacade,
                                          IWritingExamSectionCommandFacade iwritingExamSectionCommandFacade,
                                          IWebHostEnvironment root)
        {
            this.iWritingExamQueryFacade = iWritingExamQueryFacade;
            this.iWritingExamCommandFacade = iWritingExamCommandFacade;
            this.iwritingExamSectionQueryFacade = iwritingExamSectionQueryFacade;
            this.iwritingExamSectionCommandFacade = iwritingExamSectionCommandFacade;
            _root = root;

        }
        public IActionResult IeltsWriting_Load(Guid id)
        {
            var examCount = iWritingExamQueryFacade.GetWritingExamCount(id);
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
        public ActionResult IeltsWritingGridData(DataTableAjaxPostModel model, Guid id)
        {
            var WritingExamSectionList = iWritingExamQueryFacade.GetWritingExamByFilteringList(ref model, id);

            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = WritingExamSectionList
            });
        }
        public IActionResult AddIeltsWriting_Load(Guid id)
        {
            ViewBag.HasError = false;
            ViewBag.IeltsExamId = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddIeltsWriting(WritingExamQueryFacadeDto model)
        {
            try
            {
                var command = new AddWritingExamCommand();
                command.Title = model.Title;
                command.IeltsExamId = model.IeltsExamId;
                command.Description = model.Description;
                command.TimerMinuties = model.TimerMinuties;
                command.IsActive = true;
                command.IsDeleted = false;

                iWritingExamCommandFacade.AddWritingExam(command);

                return RedirectToAction("IeltsWriting_Load", new { Id = model.IeltsExamId });
            }
            catch (Exception e)
            {

                ModelState.AddModelError("AddIeltsWritingException", e.Message);
                ViewBag.HasError = true;
                ViewBag.IeltsExamId = model.IeltsExamId;
                return View("AddIeltsWriting_Load", model);
            }
            
        }
        public IActionResult EditWritingExam_Load(Guid id)
        {
            ViewBag.HasError = false;
            var WritingExamSection = iWritingExamQueryFacade.GetWritingExamById(id);
            return View(WritingExamSection);
        }
        [HttpPost]
        public IActionResult EditWritingExam(WritingExamQueryFacadeDto model)
        {
            try
            {
                var command = Mapper.Map<WritingExamQueryFacadeDto, UpdateWritingExamCommand>(model);
                iWritingExamCommandFacade.UpdateWritingExam(command);

                return RedirectToAction("IeltsWriting_Load", new { Id = model.IeltsExamId });
            }
            catch (Exception e)
            {
                ModelState.AddModelError("EditWritingExamException", e.Message);
                ViewBag.HasError = true;
                return View("EditWritingExam_Load", model);
            }
        }
        //-----------------------
        public IActionResult WritingSection_Load(Guid id)
        {
            ViewBag.WritingExamId = id;
            return View();
        }
        public ActionResult WritingSectionListGridData(DataTableAjaxPostModel model, Guid id)
        {
            var WritingExamSectionList = iwritingExamSectionQueryFacade.GetWritingExamSectionListForGridView(ref model, id);

            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = WritingExamSectionList
            });
        }
        public IActionResult AddWritingSection_Load(Guid id)
        {
            ViewBag.HasError = false;
            ViewBag.WritingExamId = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddWritingSection(WritingExamSectionQueryFacadeDto model)
        {
            try
            {
                var command = new AddWritingExamSectionCommand();
                command.Title = model.Title;
                command.TimerMinuties = model.TimerMinuties;
                command.WritingTopic = model.WritingTopic;
                command.IsActive = true;
                command.IsDeleted = false;
                command.WritingExamId = model.WritingExamId;


                iwritingExamSectionCommandFacade.AddWritingExamSection(command);

                return RedirectToAction("WritingSection_Load", new { id = model.WritingExamId });
            }
            catch (Exception e)
            {

                ModelState.AddModelError("AddWritingSectionException", e.Message);
                ViewBag.HasError = true;
                ViewBag.WritingExamId = model.WritingExamId;
                return View("AddWritingSection_Load", model);
            }
        }
        public IActionResult EditWritingExamSection_Load(Guid id, bool? hasError = false, string errorMessage = "")
        {
            ViewBag.HasError = hasError;
            ModelState.AddModelError("EditWritingExamSectionException", errorMessage);
            var WritingExamSection = iwritingExamSectionQueryFacade.GetWritingExamSectionById(id);
            return View(WritingExamSection);
        }
        [HttpPost]
        public IActionResult EditWritingExamSection(WritingExamSectionQueryFacadeDto model)
        {
            try
            {
                var command = Mapper.Map<WritingExamSectionQueryFacadeDto, UpdateWritingExamSectionCommand>(model);
                iwritingExamSectionCommandFacade.UpdateWritingExamSection(command);

                return RedirectToAction("WritingSection_Load", new { id = model.WritingExamId });
            }
            catch (Exception e)
            {

                return RedirectToAction("EditWritingExamSection_Load", new { id = model.Id, hasError = true, errorMessage = e.Message });
            }
        }

        public IActionResult WritingExamTopic_Load(Guid id)
        {
            var writingExamTopic = iwritingExamSectionQueryFacade.GetWritingExamSectionById(id)?.WritingTopic;
            if (!string.IsNullOrWhiteSpace(writingExamTopic))
            {
                ViewBag.WritingExamTopic = writingExamTopic;
            }
            return View();
        }

    }
}
