using Framework.Core.Domain;
using Framework.Domain;
using ExamContext.General.Domain.Contracts.MenuAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.General.Domain.MenuAggregate
{
    public class Menu : EntityBase, IAggregateRoot<Menu>
    {
        public Menu()
        {

        }
        public Menu(MenuDto dto)
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

        public IEnumerable<Expression<Func<Menu, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}
