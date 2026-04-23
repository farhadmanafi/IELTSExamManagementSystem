using ExamContext.Listening.Aplication.Contracts.ListeningExamAggregate;
using ExamContext.Listening.Aplication.Contracts.ListeningQuestionAggregate;
using ExamContext.Listening.Facade.Contracts.ListeningExamAggregate;
using ExamContext.Listening.Facade.Contracts.ListeningQuestionAggregate;
using ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningExamAggregate;
using ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningExamAggregate.DataContracts;
using ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningQuestionAggregate;
using ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningQuestionAggregate.DataContracts;
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
    public class IeltsExamListeningController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IListeningExamSectionQueryFacade listeningSectionQueryFacade;
        private readonly IListeningExamSectionCommandFacade listeningExamSectionCommandFacade;
        private readonly IListeningExamQuestionBlockQueryFacade listeningExamQuestionBlockQueryFacade;
        private readonly IListeningExamQuestionBlockCommandFacade listeningExamQuestionBlockCommandFacade;
        private readonly IListeningQuestionQueryFacade listeningQuestionQueryFacade;
        private readonly IListeningQuestionTypeQueryFacade listeningQuestionTypeQueryFacade;
        private readonly IListeningQuestionCommandFacade listeningQuestionCommandFacade;
        private readonly IListeningQuestionAnswersCommandFacade listeningQuestionAnswersCommandFacade;
        private readonly IListeningQuestionAnswersQueryFacade listeningQuestionAnswersQueryFacade;
        private readonly IListeningExamQueryFacade iListeningExamQueryFacade;
        private readonly IListeningExamCommandFacade iListeningExamCommandFacade;
        private readonly IWebHostEnvironment _root;
        public IeltsExamListeningController(UserManager<ApplicationUser> userManager,
                                   IListeningExamSectionQueryFacade listeningSectionQueryFacade,
                                   IListeningExamSectionCommandFacade listeningExamSectionCommandFacade,
                                   IListeningExamQuestionBlockQueryFacade listeningExamQuestionBlockQueryFacade,
                                   IListeningExamQuestionBlockCommandFacade listeningExamQuestionBlockCommandFacade,
                                   IListeningQuestionQueryFacade listeningQuestionQueryFacade,
                                   IListeningQuestionTypeQueryFacade listeningQuestionTypeQueryFacade,
                                   IListeningQuestionCommandFacade listeningQuestionCommandFacade,
                                   IListeningQuestionAnswersCommandFacade listeningQuestionAnswersCommandFacade,
                                   IListeningQuestionAnswersQueryFacade listeningQuestionAnswersQueryFacade,
                                   IListeningExamQueryFacade iListeningExamQueryFacade,
                                   IListeningExamCommandFacade iListeningExamCommandFacade,
                                   IWebHostEnvironment root)
        {
            this.userManager = userManager;
            this.listeningSectionQueryFacade = listeningSectionQueryFacade;
            this.listeningExamSectionCommandFacade = listeningExamSectionCommandFacade;
            this.listeningExamQuestionBlockQueryFacade = listeningExamQuestionBlockQueryFacade;
            this.listeningExamQuestionBlockCommandFacade = listeningExamQuestionBlockCommandFacade;
            this.listeningQuestionQueryFacade = listeningQuestionQueryFacade;
            this.listeningQuestionTypeQueryFacade = listeningQuestionTypeQueryFacade;
            this.listeningQuestionCommandFacade = listeningQuestionCommandFacade;
            this.listeningQuestionAnswersCommandFacade = listeningQuestionAnswersCommandFacade;
            this.listeningQuestionAnswersQueryFacade = listeningQuestionAnswersQueryFacade;
            this.iListeningExamQueryFacade = iListeningExamQueryFacade;
            this.iListeningExamCommandFacade = iListeningExamCommandFacade;
            this._root = root;
        }
        #region ListeningOperations
        public IActionResult IeltsListening_Load(Guid id)
        {
            var examCount = iListeningExamQueryFacade.GetListeningExamCount(id);
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
        public ActionResult IeltsListeningGridData(DataTableAjaxPostModel model, Guid id)
        {
            var listeningExamSectionList = iListeningExamQueryFacade.GetListeningExamByFilteringList(ref model, id);

            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = listeningExamSectionList
            });
        }
        public IActionResult AddIeltsListening_Load(Guid id)
        {
            ViewBag.HasError = false;
            ViewBag.IeltsExamId = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddIeltsListening(IFormFile VoiceSourceFile, IFormFile PreVoiceSourceFile, ListeningExamQueryFacadeDto model)
        {
            try
            {
                if (VoiceSourceFile == null)
                {
                    ViewBag.HasError = true;
                    ViewBag.IeltsExamId = model.IeltsExamId;
                    ModelState.AddModelError("CreatingException", "فایل صوتی نمیتواند خالی باشد");
                    return View("AddIeltsListening_Load", model);
                }
                var filename = Guid.NewGuid() + Path.GetExtension(VoiceSourceFile.FileName).ToLower();
                var path = Path.Combine(_root.WebRootPath, "soundforcontent", filename);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    VoiceSourceFile.CopyTo(stream);
                }
                var urlVoiceSourceFile = $"{"/soundforcontent/"}{filename}";

                var filenamePreVoiceSourceFile = "";
                var urlPreVoiceSourceFile = $"";
                if (PreVoiceSourceFile != null)
                {
                    filenamePreVoiceSourceFile = Guid.NewGuid() + Path.GetExtension(PreVoiceSourceFile.FileName).ToLower();
                    var pathPreVoiceSourceFile = Path.Combine(_root.WebRootPath, "soundforcontent", filenamePreVoiceSourceFile);
                    using (var stream = new FileStream(pathPreVoiceSourceFile, FileMode.Create))
                    {
                        PreVoiceSourceFile.CopyTo(stream);
                    }
                }
                urlVoiceSourceFile = $"{"/soundforcontent/"}{filenamePreVoiceSourceFile}";


                var command = new AddListeningExamCommand();
                command.Title = model.Title;
                command.IeltsExamId = model.IeltsExamId;
                command.Description = model.Description;
                command.VoiceSource = urlVoiceSourceFile;
                command.VoiceSourceFile = urlVoiceSourceFile;
                command.TimerMinuties = model.TimerMinuties;
                command.IsActive = true;
                command.IsDeleted = false;

                iListeningExamCommandFacade.AddListeningExam(command);

                return RedirectToAction("IeltsListening_Load", new { Id = model.IeltsExamId });
            }
            catch (Exception e)
            {
                ModelState.AddModelError("CreatingException", e.Message);
                ViewBag.HasError = true;
                ViewBag.IeltsExamId = model.IeltsExamId;
                return View("AddIeltsListening_Load", model);
            }

        }
        public IActionResult EditListeningExam_Load(Guid id)
        {
            ViewBag.HasError = false;
            var listeningExamSection = iListeningExamQueryFacade.GetListeningExamById(id);
            return View(listeningExamSection);
        }
        [HttpPost]
        public IActionResult EditListeningExam(IFormFile VoiceSourceFile, ListeningExamQueryFacadeDto model)
        {
            try
            {
                if (VoiceSourceFile == null)
                {
                    ModelState.AddModelError("EditListeningExamException", "فایل صوتی نمیتواند خالی باشد");
                    ViewBag.HasError = true;
                    return View("EditListeningExam_Load", model);
                }
                var filename = Guid.NewGuid() + Path.GetExtension(VoiceSourceFile.FileName).ToLower();
                var path = Path.Combine(_root.WebRootPath, "soundforcontent", filename);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    VoiceSourceFile.CopyTo(stream);
                }
                var url = $"{"/soundforcontent/"}{filename}";
                var command = Mapper.Map<ListeningExamQueryFacadeDto, UpdateListeningExamCommand>(model);
                command.VoiceSource = url;
                iListeningExamCommandFacade.UpdateListeningExam(command);

                return RedirectToAction("IeltsListening_Load", new { Id = model.IeltsExamId });
            }
            catch (Exception e)
            {
                ModelState.AddModelError("EditListeningExamException", e.Message);
                ViewBag.HasError = true;
                return View("EditListeningExam_Load", model);
                //return RedirectToAction("AddIeltsListening_Load", new { Id = model.IeltsExamId });
            }


        }

        public IActionResult PlayListeningQuestionVoice(Guid id)
        {
            var voiceUrl = iListeningExamQueryFacade.GetListeningExamById(id)?.VoiceSource;
            if (!string.IsNullOrWhiteSpace(voiceUrl))
            {
                ViewBag.VoiceURL = voiceUrl;
            }
            return View();
        }
        //-----------------------
        public IActionResult ListeningSection_Load(Guid id)
        {
            ViewBag.ListeningExamId = id;
            return View();
        }
        public ActionResult ListeningSectionListGridData(DataTableAjaxPostModel model, Guid id)
        {
            var listeningExamSectionList = listeningSectionQueryFacade.GetListeningExamSectionListForGridView(ref model, id);

            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = listeningExamSectionList
            });
        }
        public IActionResult AddListeningSection_Load(Guid id)
        {
            ViewBag.HasError = false;
            ViewBag.ListeningExamId = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddListeningSection(ListeningExamSectionQueryFacadeDto model)
        {
            try
            {
                var command = new AddListeningExamSectionCommand();
                command.Title = model.Title;
                command.OrderNo = model.OrderNo;
                command.IsActive = true;
                command.IsDeleted = false;
                command.ListeningExamId = model.ListeningExamId;


                listeningExamSectionCommandFacade.AddListeningExamSection(command);

                return RedirectToAction("ListeningSection_Load", new { id = model.ListeningExamId });
            }
            catch (Exception e)
            {
                ModelState.AddModelError("ListeningSectionException", e.Message);
                ViewBag.HasError = true;
                ViewBag.ListeningExamId = model.ListeningExamId;
                return View("AddListeningSection_Load", model);
                //return RedirectToAction("AddIeltsListening_Load", new { Id = model.IeltsExamId });
            }

        }
        public IActionResult EditListeningExamSection_Load(Guid id)
        {
            ViewBag.HasError = false;
            var listeningExamSection = listeningSectionQueryFacade.GetListeningExamSection(id);
            return View(listeningExamSection);
        }
        [HttpPost]
        public IActionResult EditListeningExamSection(ListeningExamSectionQueryFacadeDto model)
        {
            try
            {
                var command = Mapper.Map<ListeningExamSectionQueryFacadeDto, UpdateListeningExamSectionCommand>(model);
                listeningExamSectionCommandFacade.UpdateListeningExamSection(command);

                return RedirectToAction("ListeningSection_Load", new { id = model.ListeningExamId });

            }
            catch (Exception e)
            {
                ModelState.AddModelError("EditListeningSectionException", e.Message);
                ViewBag.HasError = true;
                return View("EditListeningExamSection_Load", model);
                //return RedirectToAction("AddIeltsListening_Load", new { Id = model.IeltsExamId });
            }
        }
        //-----------------------
        public IActionResult ListeningQuestionBlock_Load(Guid id)
        {
            ViewBag.ListeningExamSectionId = id;
            return View();
        }
        public IActionResult ListeningQuestionBlockListGridData(DataTableAjaxPostModel model, Guid id)
        {
            var listeningExamQuestionBlockList = listeningExamQuestionBlockQueryFacade.GetListeningExamQuestionBlockListForGridView(ref model, id);

            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = listeningExamQuestionBlockList
            });
        }
        public IActionResult AddListeningQuestionBlock_Load(Guid id)
        {
            ViewBag.HasError = false;
            ViewBag.ListeningExamSectionId = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddListeningQuestionBlock(ListeningExamQuestionBlockQueryFacadeDto model)
        {
            try
            {
                var command = new AddListeningExamQuestionBlockCommand();
                command.Title = model.Title;
                command.OrderNo = model.OrderNo;
                command.Description = model.Description;
                command.ListeningExamSectionId = model.ListeningExamSectionId;
                command.IsActive = true;
                command.IsDeleted = false;

                listeningExamQuestionBlockCommandFacade.AddListeningExamQuestionBlock(command);

                return RedirectToAction("ListeningQuestionBlock_Load", new { id = model.ListeningExamSectionId });
            }
            catch (Exception e)
            {
                ModelState.AddModelError("ListeningQuestionBlockException", e.Message);
                ViewBag.HasError = true;
                ViewBag.ListeningExamSectionId = model.ListeningExamSectionId;
                return View("AddListeningQuestionBlock_Load", model);
            }

        }
        public IActionResult EditListeningExamQuestionBlock_Load(Guid id)
        {
            ViewBag.HasError = false;
            var listeningExamQuestionBlock = listeningExamQuestionBlockQueryFacade.GetListeningExamQuestionBlock(id);
            return View(listeningExamQuestionBlock);
        }
        [HttpPost]
        public IActionResult EditListeningExamQuestionBlock(ListeningExamQuestionBlockQueryFacadeDto model)
        {
            try
            {
                var command = Mapper.Map<ListeningExamQuestionBlockQueryFacadeDto, UpdateListeningExamQuestionBlockCommand>(model);
                listeningExamQuestionBlockCommandFacade.UpdateListeningExamQuestionBlock(command);

                return RedirectToAction("ListeningQuestionBlock_Load", new { id = model.ListeningExamSectionId });
            }
            catch (Exception e)
            {
                ModelState.AddModelError("EditListeningExamQuestionBlock", e.Message);
                ViewBag.HasError = true;
                return View("EditListeningExamQuestionBlock_Load", model);
            }
        }
        //-----------------------
        public IActionResult ListeningQuestionList(Guid id)
        {
            ViewBag.ListeningExamId = id;
            return View();
        }
        public IActionResult ListeningQuestionListGridData(DataTableAjaxPostModel model, Guid id)
        {
            var listeningQuestionList = listeningQuestionQueryFacade.GetListeningQuestionListForGridView(ref model, id);

            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = listeningQuestionList
            });
        }
        public IActionResult AddListeningQuestion_Load(Guid id, bool? hasError = false, string errorMessage = "")
        {
            ViewBag.HasError = hasError;
            ModelState.AddModelError("ListeningQuestionException", errorMessage);
            ViewBag.ListeningExamId = id;
            ViewBag.ListeningQuestionTypeList = GetListeningQuestionTypeist();
            ViewBag.ListeningExamSectionList = GetListeningSectionistById(id);

            return View();
        }


        [HttpPost]
        public IActionResult AddListeningQuestion(ListeningQuestionQueryFacadeDto model)
        {
            try
            {
                var command = new AddListeningQuestionCommand();
                command.Title = model.Title;
                command.Description = model.Description;
                command.ListeningExamId = model.ListeningExamId;//TODO IMPORTANT! Exam Id should be added to all questions and mappings
                command.OrderNo = model.OrderNo;
                command.ListeningQuestionTypeId = model.ListeningQuestionTypeId;
                command.ListeningExamSectionId = model.ListeningExamSectionId;
                command.ListeningExamQuestionBlockId = model.ListeningExamQuestionBlockId;
                command.IsActive = model.IsActive;
                command.IsDeleted = false;

                listeningQuestionCommandFacade.AddListeningQuestion(command);

                return RedirectToAction("ListeningQuestionList", new { Id = model.ListeningExamId });
            }
            catch (Exception e)
            {
                return RedirectToAction("AddListeningQuestion_Load", new { id = model.ListeningExamId, hasError = true, errorMessage = e.Message });
            }
        }
        public IActionResult EditListeningQuestion_Load(Guid id, bool? hasError = false, string errorMessage = "")
        {
            var data = listeningQuestionQueryFacade.GetListeningQuestion(id);
            ViewBag.HasError = hasError;
            ModelState.AddModelError("EditListeningQuestionException", errorMessage);

            var listeningQuestionTypeList = listeningQuestionTypeQueryFacade.GetListeningQuestionTypeListQueryFacade();
            ViewBag.ListeningQuestionTypeList = new SelectList(listeningQuestionTypeList, "Id", "Title", data.ListeningQuestionTypeId);

            var listeningExamSectionList = listeningSectionQueryFacade.GetListeningExamSectionListByListeningExamId(data.ListeningExamId);
            ViewBag.ListeningExamSectionList = new SelectList(listeningExamSectionList, "Id", "Title", data.ListeningExamSectionId);

            var listeningExamQuestionBlocList = listeningExamQuestionBlockQueryFacade.GetListeningExamQuestionBlocListByListeningSectionId(data.ListeningExamSectionId);
            ViewBag.ListeningExamQuestionBlocList = new SelectList(listeningExamQuestionBlocList, "Id", "Title", data.ListeningExamQuestionBlockId);

            return View(data);
        }
        [HttpPost]
        public IActionResult EditListeningQuestion(ListeningQuestionQueryFacadeDto model)
        {
            try
            {
                var command = Mapper.Map<ListeningQuestionQueryFacadeDto, UpdateListeningQuestionCommand>(model);
                listeningQuestionCommandFacade.UpdateListeningQuestion(command);

                return RedirectToAction("ListeningQuestionList", new { Id = model.ListeningExamId });
            }
            catch (Exception e)
            {

                return RedirectToAction("EditListeningQuestion_Load", new { id = model.Id, hasError = true, errorMessage = e.Message });
            }
        }

        [HttpPost]
        public JsonResult GetListeningExamQuestionBlocListByListeningSectionId(Guid listeningExamSectionId)
        {
            var listeningExamQuestionBlocList = listeningExamQuestionBlockQueryFacade.GetListeningExamQuestionBlocListByListeningSectionId(listeningExamSectionId);
            var listeningExamQuestionBlocLists = new SelectList(listeningExamQuestionBlocList, "Id", "Title");

            return Json(listeningExamQuestionBlocLists);
        }
        //-----------------------
        public IActionResult ListeningQuestionAnswerList(Guid id)
        {
            ViewBag.ListeningQuestionId = id;
            return View();
        }
        public IActionResult ListeningQuestionAnswerListGridData(DataTableAjaxPostModel model, Guid id)
        {
            var listeningQuestionAnswerList = listeningQuestionAnswersQueryFacade.GetListeningQuestionAnswerListForGridView(ref model, id);

            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = listeningQuestionAnswerList
            });

        }
        public IActionResult AddListeningQuestionAnswer_Load(System.Guid id, bool? hasError = false, string errorMessage = "")
        {
            ViewBag.HasError = hasError;
            ModelState.AddModelError("AddListeningQuestionAnswerException", errorMessage);
            ViewBag.ListeningQuestionId = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddListeningQuestionAnswer(ListeningQuestionAnswersQueryFacadeDto model)
        {
            try
            {
                var command = new AddListeningQuestionAnswersCommand();
                command.Title = model.Title;
                command.Description = model.Description;
                command.ListeningQuestionId = model.ListeningQuestionId;
                command.OrderNo = model.OrderNo;
                command.IsCorrect = model.IsCorrect;
                command.IsActive = model.IsActive;
                command.IsDeleted = false;

                listeningQuestionAnswersCommandFacade.AddListeningQuestionAnswers(command);

                return RedirectToAction("ListeningQuestionAnswerList", new { id = model.ListeningQuestionId });
            }
            catch (Exception e)
            {

                return RedirectToAction("AddListeningQuestionAnswer_Load", new { id = model.ListeningQuestionId, hasError = true, errorMessage = e.Message });
            }
        }
        public IActionResult EditListeningQuestionAnswer_Load(Guid id, bool? hasError = false, string errorMessage = "")
        {
            var data = listeningQuestionAnswersQueryFacade.GetListeningQuestionAnswers(id);
            ViewBag.HasError = hasError;
            ModelState.AddModelError("EditListeningQuestionAnswer", errorMessage);
            return View(data);

        }
        [HttpPost]
        public IActionResult EditListeningQuestionAnswer(ListeningQuestionAnswersQueryFacadeDto model)
        {
            try
            {
                var command = Mapper.Map<ListeningQuestionAnswersQueryFacadeDto, UpdateListeningQuestionAnswersCommand>(model);
                listeningQuestionAnswersCommandFacade.UpdateListeningQuestionAnswers(command);

                return RedirectToAction("ListeningQuestionAnswerList", new { id = model.ListeningQuestionId });
            }
            catch (Exception e)
            {

                return RedirectToAction("EditListeningQuestionAnswer_Load", new { id = model.Id, hasError = true, errorMessage = e.Message });
            }
        }

        private SelectList GetListeningSectionistById(Guid id)
        {
            var listeningExamSectionList = listeningSectionQueryFacade.GetListeningExamSectionListByListeningExamId(id);
            return new SelectList(listeningExamSectionList, "Id", "Title");
        }

        private SelectList GetListeningQuestionTypeist()
        {
            var listeningQuestionTypeList = listeningQuestionTypeQueryFacade.GetListeningQuestionTypeListQueryFacade();
            return new SelectList(listeningQuestionTypeList, "Id", "Title");
        }

        #endregion
    }
}
