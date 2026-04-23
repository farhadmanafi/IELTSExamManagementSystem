using ExamContext.ReadModel.Queries.Contracts.GeneralContext.MenuAggregate;
using Microsoft.AspNetCore.Mvc;

namespace IeltsProject.AdminPresentation.ViewComponents
{
    public class _AsideMenuViewComponent : ViewComponent
    {
        private readonly IMenuQueryFacade menuQueryFacade;
        public _AsideMenuViewComponent(IMenuQueryFacade menuQueryFacade)
        {
            this.menuQueryFacade = menuQueryFacade;
        }
        public IViewComponentResult Invoke() {
            var menuList = menuQueryFacade.GetMenus();

            return View(menuList);
        }
    }
}
