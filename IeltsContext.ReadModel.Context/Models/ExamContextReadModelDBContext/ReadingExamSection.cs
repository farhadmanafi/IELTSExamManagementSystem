using System;
using System.Collections.Generic;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class ReadingExamSection
    {
        public ReadingExamSection()
        {
            ReadingExamQuestionBlocks = new HashSet<ReadingExamQuestionBlock>();
        }

        public Guid Id { get; set; }
        public Guid ReadingExamId { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Description { get; set; }
        public string ReadingText { get; set; }
        public int OrderNo { get; set; }

        public virtual ReadingExam ReadingExam { get; set; }
        public virtual ICollection<ReadingExamQuestionBlock> ReadingExamQuestionBlocks { get; set; }
    }
}
