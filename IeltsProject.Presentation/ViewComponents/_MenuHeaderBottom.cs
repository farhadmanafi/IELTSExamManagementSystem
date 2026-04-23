using ExamContext.ReadModel.Queries.Contracts.GeneralContext.UserPanelMenuAggregate;
using Microsoft.AspNetCore.Mvc;

namespace IeltsProject.AdminPresentation.ViewComponents
{
    public class _MenuHeaderBottomViewComponent : ViewComponent
    {
        private readonly IUserPanelMenuQueryFacade iUserPanelMenuQueryFacade;
        public _MenuHeaderBottomViewComponent(IUserPanelMenuQueryFacade iUserPanelMenuQueryFacade)
        {
            this.iUserPanelMenuQueryFacade = iUserPanelMenuQueryFacade;
        }
        public IViewComponentResult Invoke() {
            var menuList = iUserPanelMenuQueryFacade.GetMenusHeaderBottom();

            return View(menuList);
        }
    }
}
