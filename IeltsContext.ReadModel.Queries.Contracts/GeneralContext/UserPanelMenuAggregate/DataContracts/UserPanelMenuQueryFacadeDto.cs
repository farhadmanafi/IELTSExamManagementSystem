using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.GeneralContext.UserPanelMenuAggregate.DataContracts
{
    public class UserPanelMenuQueryFacadeDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid? ParentMenuId { get; set; }
        public string Url { get; set; }
        public string PageName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Icon { get; set; }
        public int OrderNo { get; set; }
    }
}
