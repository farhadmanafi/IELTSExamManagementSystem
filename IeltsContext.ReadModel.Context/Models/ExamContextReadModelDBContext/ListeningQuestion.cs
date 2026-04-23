using System;
using System.Collections.Generic;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class ListeningQuestion
    {
        public ListeningQuestion()
        {
            ListeningQuestionAnswers = new HashSet<ListeningQuestionAnswer>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Guid ListeningQuestionTypeId { get; set; }
        public DateTime TimeStamp { get; set; }
        public float Score { get; set; }
        public Guid ListeningExamId { get; set; }
        public Guid ListeningExamQuestionBlockId { get; set; }
        public Guid ListeningExamSectionId { get; set; }

        public virtual ListeningQuestionType ListeningQuestionType { get; set; }
        public virtual ICollection<ListeningQuestionAnswer> ListeningQuestionAnswers { get; set; }
    }
}
