using System;
using System.Collections.Generic;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class PlacementUserScore
    {
        public Guid Id { get; set; }
        public Guid PlacementExamId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime ExamDate { get; set; }
        public Guid LevelScoreId { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual LevelScore LevelScore { get; set; }
    }
}
