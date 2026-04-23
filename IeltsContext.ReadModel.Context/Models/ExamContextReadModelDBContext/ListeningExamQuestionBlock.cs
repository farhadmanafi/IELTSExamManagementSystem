using System;
using System.Collections.Generic;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class ListeningExamQuestionBlock
    {
        public Guid Id { get; set; }
        public Guid ListeningExamSectionId { get; set; }
        public string Title { get; set; }
        public int OrderNo { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual ListeningExamSection ListeningExamSection { get; set; }
    }
}
