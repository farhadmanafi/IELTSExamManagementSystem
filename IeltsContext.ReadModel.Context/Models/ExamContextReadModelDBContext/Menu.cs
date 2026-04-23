using System;
using System.Collections.Generic;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class Menu
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid? ParentMenuId { get; set; }
        public string Url { get; set; }
        public string PageName { get; set; }
        public string Icon { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeStamp { get; set; }
        public int OrderNo { get; set; }
    }
}
