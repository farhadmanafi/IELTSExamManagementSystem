using System;
using System.Collections.Generic;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class LevelScore
    {
        public LevelScore()
        {
            PlacementUserScores = new HashSet<PlacementUserScore>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string LevelName { get; set; }
        public int MinScore { get; set; }
        public int MaxScore { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual ICollection<PlacementUserScore> PlacementUserScores { get; set; }
    }
}
