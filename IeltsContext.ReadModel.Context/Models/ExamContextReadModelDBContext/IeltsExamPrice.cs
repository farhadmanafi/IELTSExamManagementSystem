using System;
using System.Collections.Generic;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class IeltsExamPrice
    {
        public Guid Id { get; set; }
        public long PriceAmount { get; set; }
        public int? DiscontentAmount { get; set; }
        public DateTime? ActivedDate { get; set; }
        public DateTime? DeactivedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Guid IeltsExamId { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual IeltsExam IeltsExam { get; set; }
    }
}
