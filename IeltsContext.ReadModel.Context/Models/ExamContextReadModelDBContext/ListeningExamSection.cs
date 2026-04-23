using System;
using System.Collections.Generic;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class ListeningExamSection
    {
        public ListeningExamSection()
        {
            ListeningExamQuestionBlocks = new HashSet<ListeningExamQuestionBlock>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Guid ListeningExamId { get; set; }
        public DateTime TimeStamp { get; set; }
        public int OrderNo { get; set; }

        public virtual ListeningExam ListeningExam { get; set; }
        public virtual ICollection<ListeningExamQuestionBlock> ListeningExamQuestionBlocks { get; set; }
    }
}
