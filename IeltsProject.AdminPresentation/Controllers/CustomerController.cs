using ExamContext.ReadModel.Queries.Contracts.UserContext;
using Ielts.Common.GeneralClass;
using Microsoft.AspNetCore.Mvc;

namespace IeltsProject.AdminPresentation.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUserSpecificationQueryFacade iuserSpecificationQueryFacade;
        public CustomerController(IUserSpecificationQueryFacade iuserSpecificationQueryFacade)
        {
            this.iuserSpecificationQueryFacade = iuserSpecificationQueryFacade;
        }
        public IActionResult CustomerList()
        {
            return View();
        }
        public ActionResult GetUserListData(DataTableAjaxPostModel model)
        {
            var userList = iuserSpecificationQueryFacade.GetUserSpecification(ref model);

            return Json(new
            {
                draw = model.draw,
                recordsFiltered = model.filteredResultsCount,
                data = userList
            });
        }
    }
}
