using ExamContext.Ielts.Aplication.Contracts.ResualtAggregarte;
using ExamContext.Ielts.Facade.Contracts.ResualtAggregarte;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ParticipantsAggregate;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ResualtAggregarte;
using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingUserAnswerAggregate;
using Ielts.Common.GeneralClass;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IeltsProject.AdminPresentation.Controllers
{
    public class IeltsExamReadingResultController : Controller
    {
        private readonly IReadingUserAnswerQueryFacade iReadingUserAnswerQueryFacade;
        private readonly IUserResualtFacade iuserResaultCommandFacade;
        private readonly IUserResualtQueryFacade iuserResualtQueryFacade;
        private readonly IIeltsExamParticipantsDetailQueryFacade iIeltsExamParticipantsDetailQueryFacade;
        public IeltsExamReadingResultController(IReadingUserAnswerQueryFacade iReadingUserAnswerQueryFacade,
                                                IUserResualtFacade iuserResaultCommandFacade,
                                                IUserResualtQueryFacade iuserResualtQueryFacade,
                                                IIeltsExamParticipantsDetailQueryFacade iIeltsExamParticipantsDetailQueryFacade)
        {
            this.iReadingUserAnswerQueryFacade = iReadingUserAnswerQueryFacade;
            this.iuserResaultCommandFacade = iuserResaultCommandFacade;
            this.iuserResualtQueryFacade = iuserResualtQueryFacade;
            this.iIeltsExamParticipantsDetailQueryFacade = iIeltsExamParticipantsDetailQueryFacade;
        }
        public IActionResult IeltsExamReadingResult_Load(Guid customerId, Guid ieltsExamParticipantsId)
        {
            var examScore = iuserResualtQueryFacade.GetUserExamResult(ieltsExamParticipantsId, customerId);
            if (examScore.ReadingScore != null)
            {
                ViewBag.HasReadingScore = true;
                ViewBag.ReadingScore = examScore.ReadingScore;
            }
            else
            {
                ViewBag.HasReadingScore = false;
                ViewBag.Scores = new List<SelectListItem>{ new SelectListItem { Value="0",Text="0"},
                                                     new SelectListItem { Value="0.5",Text="0.5"},
                                                     new SelectListItem { Value="1",Text="1"},
                                                     new SelectListItem { Value="1.5",Text="1.5"},
                                                     new SelectListItem { Value="2",Text="2"},
                                                     new SelectListItem { Value="2.5",Text="2.5"},
                                                     new SelectListItem { Value="3",Text="3"},
                                                     new SelectListItem { Value="3.5",Text="3.5"},
                                                     new SelectListItem { Value="4",Text="4"},
                                                     new SelectListItem { Value="4.5",Text="4.5"},
                                                     new SelectListItem { Value="5",Text="5"},
                                                     new SelectListItem { Value="5.5",Text="5.5"},
                                                     new SelectListItem { Value="6",Text="6"},
                                                     new SelectListItem { Value="6.5",Text="6.5"},
                                                     new SelectListItem { Value="7",Text="7"},
                                                     new SelectListItem { Value="7.5",Text="7.5"},
                                                     new SelectListItem { Value="8",Text="8"},
                                                     new SelectListItem { Value="8.5",Text="8.5"},
                                                     new SelectListItem { Value="9",Text="9"}};
            }
            ViewBag.CustomerId = customerId;
            ViewBag.IeltsExamParticipantsId = ieltsExamParticipantsId;
            return View();
        }
        public ActionResult IeltsExamReadingUserScoreDetailData(DataTableAjaxPostModel model, Guid id)
        {
            var ieltsExamParticipantsDetail = iIeltsExamParticipantsDetailQueryFacade.GetIeltsExamParticipantsDetailByIeltsExamParticipantsId(id);

            var readingUserScoreList = iReadingUserAnswerQueryFacade.GetReadingExamUserAnswerListByIeltsExamId(ref model, ieltsExamParticipantsDetail.ReadingExamId, ieltsExamParticipantsDetail.IeltsExamParticipantsId);

            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = readingUserScoreList
            });
        }
        [HttpPost]
        public IActionResult AddScore(float readingExamScore, Guid customerId, Guid ieltsExamParticipantsId)
        {
            var command = new UpdateReadingScoreCommand();
            command.IeltsExamParticipantsId = ieltsExamParticipantsId;
            command.CustomerId = customerId;
            command.ReadingScore = readingExamScore;

            iuserResaultCommandFacade.UpdateReadingScore(command);

            return RedirectToAction("IeltsExamParticipantResult_Load", "IeltsExamResult", new { customerId = customerId, ieltsExamParticipantsId = ieltsExamParticipantsId });
        }
    }
}
