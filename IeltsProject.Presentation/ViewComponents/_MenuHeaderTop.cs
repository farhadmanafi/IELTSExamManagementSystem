using ExamContext.ReadModel.Queries.Contracts.GeneralContext.UserPanelMenuAggregate;
using Microsoft.AspNetCore.Mvc;

namespace IeltsProject.AdminPresentation.ViewComponents
{
    public class _MenuHeaderTopViewComponent : ViewComponent
    {
        private readonly IUserPanelMenuQueryFacade iUserPanelMenuQueryFacade;
        public _MenuHeaderTopViewComponent(IUserPanelMenuQueryFacade iUserPanelMenuQueryFacade)
        {
            this.iUserPanelMenuQueryFacade = iUserPanelMenuQueryFacade;
        }
        public IViewComponentResult Invoke() {
            var menuList = iUserPanelMenuQueryFacade.GetMenusHeaderTop();

            return View(menuList);
        }
    }
}
