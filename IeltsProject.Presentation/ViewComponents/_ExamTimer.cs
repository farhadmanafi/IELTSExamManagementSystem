using ExamContext.ReadModel.Queries.Contracts.GeneralContext.UserPanelMenuAggregate;
using Microsoft.AspNetCore.Mvc;

namespace IeltsProject.AdminPresentation.ViewComponents
{
    public class _ExamTimerViewComponent : ViewComponent
    {
        public _ExamTimerViewComponent()
        {
        }
        public IViewComponentResult Invoke() {

            return View();
        }
    }
}
