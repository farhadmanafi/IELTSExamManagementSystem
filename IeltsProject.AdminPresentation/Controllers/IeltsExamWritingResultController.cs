using ExamContext.Ielts.Aplication.Contracts.ResualtAggregarte;
using ExamContext.Ielts.Facade.Contracts.ResualtAggregarte;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ParticipantsAggregate;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ResualtAggregarte;
using ExamContext.ReadModel.Queries.Contracts.WritingContext.WritingExamAggregate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IeltsProject.AdminPresentation.Controllers
{
    public class IeltsExamWritingResultController : Controller
    {
        private readonly IWritingExamSectionQueryFacade iwritingExamSectionQueryFacade;
        private readonly IUserResualtFacade iuserResaultCommandFacade;
        private readonly IUserResualtQueryFacade iuserResualtQueryFacade;
        private readonly IIeltsExamParticipantsDetailQueryFacade iIeltsExamParticipantsDetailQueryFacade;
        public IeltsExamWritingResultController(IWritingExamSectionQueryFacade iwritingExamSectionQueryFacade,
                                                IUserResualtFacade iuserResaultCommandFacade,
                                                IUserResualtQueryFacade iuserResualtQueryFacade,
                                                  IIeltsExamParticipantsDetailQueryFacade iIeltsExamParticipantsDetailQueryFacade)
        {
            this.iwritingExamSectionQueryFacade = iwritingExamSectionQueryFacade;
            this.iuserResaultCommandFacade = iuserResaultCommandFacade;
            this.iuserResualtQueryFacade = iuserResualtQueryFacade;
            this.iIeltsExamParticipantsDetailQueryFacade = iIeltsExamParticipantsDetailQueryFacade;
        }
        public IActionResult IeltsExamWritingResult_Load(Guid customerId,Guid ieltsExamParticipantsId)
        {
            var ieltsExamParticipantsDetail = iIeltsExamParticipantsDetailQueryFacade.GetIeltsExamParticipantsDetailByIeltsExamParticipantsId(ieltsExamParticipantsId);

            var result = iwritingExamSectionQueryFacade.GetWrtingExamUserAnswersPerSectionByExamId(ieltsExamParticipantsDetail.WritingExamId, customerId);
            var examScore = iuserResualtQueryFacade.GetUserExamResult(ieltsExamParticipantsId, customerId);
            if (examScore.WritingScore != null)
            {
                ViewBag.HasWritingScore = true;
                ViewBag.WritingScore = examScore.WritingScore;
            }
            else
            {
                ViewBag.HasWritingScore = false;
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
            return View(result);
        }
        [HttpPost]
        public IActionResult AddScore(float writingExamScore, Guid customerId, Guid ieltsExamParticipantsId)
        {
            var command = new UpdateWritingScoreCommand();
            command.IeltsExamParticipantsId = ieltsExamParticipantsId;
            command.CustomerId = customerId;
            command.WritingScore = writingExamScore;
            iuserResaultCommandFacade.UpdateWritingScore(command);
            return RedirectToAction("IeltsExamParticipantResult_Load", "IeltsExamResult", new { customerId = customerId, ieltsExamParticipantsId = ieltsExamParticipantsId });
        }
    }
}
