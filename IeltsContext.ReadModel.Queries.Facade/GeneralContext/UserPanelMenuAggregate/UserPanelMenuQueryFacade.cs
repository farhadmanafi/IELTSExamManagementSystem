using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.GeneralContext.UserPanelMenuAggregate;
using ExamContext.ReadModel.Queries.Contracts.GeneralContext.UserPanelMenuAggregate.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Facade.GeneralContext.UserPanelMenuAggregate
{
    public class UserPanelMenuQueryFacade : IUserPanelMenuQueryFacade
    {
        public IEnumerable<UserPanelMenuQueryFacadeDto> GetMenusHeaderBottom()
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.UserPanelMenus.Where(a => a.IsActive == true && a.IsDeleted == false)
                            select new UserPanelMenuQueryFacadeDto()
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
                            }).OrderBy(a => a.OrderNo).ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<UserPanelMenuQueryFacadeDto> GetMenusHeaderTop()
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.UserPanelMenus.Where(a => a.IsActive == true && a.IsDeleted == false && a.ParentMenuId == null)
                            select new UserPanelMenuQueryFacadeDto()
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
                            }).OrderBy(a => a.OrderNo).ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
