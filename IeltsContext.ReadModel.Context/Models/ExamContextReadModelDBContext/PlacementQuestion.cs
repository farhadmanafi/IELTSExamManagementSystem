using System;
using System.Collections.Generic;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class PlacementQuestion
    {
        public PlacementQuestion()
        {
            PlacementQuestionAnswers = new HashSet<PlacementQuestionAnswer>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Guid PlacementQuestionTypeId { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid PlacementExamtId { get; set; }

        public virtual PlacementQuestionType PlacementQuestionType { get; set; }
        public virtual ICollection<PlacementQuestionAnswer> PlacementQuestionAnswers { get; set; }
    }
}
