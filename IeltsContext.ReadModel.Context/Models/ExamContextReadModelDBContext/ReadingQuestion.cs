using System;
using System.Collections.Generic;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class ReadingQuestion
    {
        public ReadingQuestion()
        {
            ReadingQuestionAnswers = new HashSet<ReadingQuestionAnswer>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Guid ReadingQuestionTypeId { get; set; }
        public DateTime TimeStamp { get; set; }
        public float Score { get; set; }
        public Guid ReadingExamId { get; set; }
        public Guid ReadingExamQuestionBlockId { get; set; }
        public Guid ReadingExamSectionId { get; set; }

        public virtual ReadingQuestionType ReadingQuestionType { get; set; }
        public virtual ICollection<ReadingQuestionAnswer> ReadingQuestionAnswers { get; set; }
    }
}
