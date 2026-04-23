using System;
using System.Collections.Generic;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class WritingUserText
    {
        public Guid Id { get; set; }
        public Guid IeltsExamId { get; set; }
        public string ContextText { get; set; }
        public Guid UserId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
