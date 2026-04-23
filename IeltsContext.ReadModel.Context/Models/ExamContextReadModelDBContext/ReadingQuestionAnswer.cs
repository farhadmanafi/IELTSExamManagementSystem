using System;
using System.Collections.Generic;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class ReadingQuestionAnswer
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Guid ReadingQuestionId { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool? IsCorrect { get; set; }

        public virtual ReadingQuestion ReadingQuestion { get; set; }
    }
}
