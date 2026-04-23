using ExamContext.General.Domain.Contracts.UserPanelMenuAggregate;
using Framework.Core.Domain;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.General.Domain.UserPanelMenuAggregate
{
    public class UserPanelMenu : EntityBase, IAggregateRoot<UserPanelMenu>
    {
        public UserPanelMenu()
        {

        }
        public UserPanelMenu(UserPanelMenuDto dto)
        {
            Title = dto.Title;
            ParentMenuId = dto.ParentMenuId;
            OrderNo = dto.OrderNo;
            Url = dto.Url;
            PageName = dto.PageName;
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
            Icon = dto.Icon;
        }

        public string Title { get; set; }
        public Guid? ParentMenuId { get; set; }
        public int OrderNo { get; set; }
        public string Url { get; set; }
        public string PageName { get; set; }
        public string Icon { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }


        public IEnumerable<Expression<Func<UserPanelMenu, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}
