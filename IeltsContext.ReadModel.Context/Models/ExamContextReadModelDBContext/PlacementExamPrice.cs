using System;
using System.Collections.Generic;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class PlacementExamPrice
    {
        public Guid Id { get; set; }
        public long PriceAmount { get; set; }
        public int? DiscontentAmount { get; set; }
        public DateTime? ActivedDate { get; set; }
        public DateTime? DeactivedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Guid PlacementExamId { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual PlacementExam PlacementExam { get; set; }
    }
}
