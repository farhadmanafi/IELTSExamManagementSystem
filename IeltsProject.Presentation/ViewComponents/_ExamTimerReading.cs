using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingExamAggregate;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IeltsProject.Presentation.ViewComponents
{
    public class _ExamTimerReadingViewComponent : ViewComponent
    {
        private readonly IReadingExamQueryFacade iReadingExamQueryFacade;
        public _ExamTimerReadingViewComponent(IReadingExamQueryFacade iReadingExamQueryFacade)
        {
            this.iReadingExamQueryFacade = iReadingExamQueryFacade; 
        }
        public IViewComponentResult Invoke(Guid id)
        {
            var data = iReadingExamQueryFacade.GetReadingExamForUserPanel(id); 
            ViewBag.TimerAmount = data.TimerMinuties;

            return View();
        }
    }
}


