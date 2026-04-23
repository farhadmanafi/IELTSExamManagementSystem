using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.GeneralContext.MenuAggregate;
using ExamContext.ReadModel.Queries.Contracts.GeneralContext.MenuAggregate.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Facade.GeneralContext.MenuAggregate
{
    public class MenuQueryFacade : IMenuQueryFacade
    {
        public IEnumerable<MenuQueryFacadeDto> GetMenus()
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.Menus.Where(a=> a.IsActive == true && a.IsDeleted == false)
                            select new MenuQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                ParentMenuId = i.ParentMenuId,
                                Url = i.Url,
                                PageName = i.PageName,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                Icon = i.Icon,
                                OrderNo = i.OrderNo
                            }).OrderBy(a=>a.OrderNo).ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
