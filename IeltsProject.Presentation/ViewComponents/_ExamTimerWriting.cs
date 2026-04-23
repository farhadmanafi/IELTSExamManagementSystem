using ExamContext.ReadModel.Queries.Contracts.WritingContext.WritingExamAggregate;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IeltsProject.Presentation.ViewComponents
{
    public class _ExamTimerWritingViewComponent : ViewComponent
    {
        private readonly IWritingExamQueryFacade iWritingExamQueryFacade;
        public _ExamTimerWritingViewComponent(IWritingExamQueryFacade iWritingExamQueryFacade)
        {
            this.iWritingExamQueryFacade = iWritingExamQueryFacade;
        }
        public IViewComponentResult Invoke(Guid id)
        {
            var data = iWritingExamQueryFacade.GetWritingExamForUserPanel(id);
            ViewBag.TimerAmount = data.TimerMinuties;

            return View();
        }
    }
}


