using System;
using System.Collections.Generic;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class ListeningExamQuesionBlock
    {
        public Guid Id { get; set; }
        public Guid ListeningExamId { get; set; }
        public string Title { get; set; }
        public int StartQuestionNumber { get; set; }
        public int EndQuestionNumber { get; set; }
        public string Description { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual ListeningExam ListeningExam { get; set; }
    }
}
