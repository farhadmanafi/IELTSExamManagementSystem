using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.General.Domain.Contracts.MenuAggregate
{
    public class MenuDto
    {
        public string Title { get; set; }
        public Guid? ParentMenuId { get; set; }
        public int OrderNo { get; set; }
        public string Url { get; set; }
        public string PageName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Icon { get; set; }
    }
}
