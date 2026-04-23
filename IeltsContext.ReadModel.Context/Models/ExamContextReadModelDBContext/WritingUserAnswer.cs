using System;
using System.Collections.Generic;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class WritingUserAnswer
    {
        public Guid Id { get; set; }
        public Guid WritingExamSectionId { get; set; }
        public string AnswerText { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime RegisterDateTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid IeltsExamParticipantId { get; set; }
    }
}
