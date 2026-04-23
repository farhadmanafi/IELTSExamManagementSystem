using System;
using System.Collections.Generic;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class WritingExamSection
    {
        public Guid Id { get; set; }
        public Guid WritingExamId { get; set; }
        public string Title { get; set; }
        public string WritingTopic { get; set; }
        public int? TimerMinuties { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual WritingExam WritingExam { get; set; }
    }
}
