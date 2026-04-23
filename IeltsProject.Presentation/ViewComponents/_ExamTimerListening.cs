using ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningExamAggregate;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IeltsProject.Presentation.ViewComponents
{
    public class _ExamTimerListeningViewComponent : ViewComponent
    {
        private readonly IListeningExamQueryFacade iListeningExamQueryFacade;
        public _ExamTimerListeningViewComponent(IListeningExamQueryFacade iListeningExamQueryFacade)
        {
            this.iListeningExamQueryFacade = iListeningExamQueryFacade;
        }
        public IViewComponentResult Invoke(Guid id)
        {
            var data = iListeningExamQueryFacade.GetListeningExamForUserPanel(id);
            ViewBag.TimerAmount = data.TimerMinuties;

            return View();
        }
    }
}


