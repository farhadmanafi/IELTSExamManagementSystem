using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Domain.Contracts.PlacementUserScoreAggregate
{
    public class LevelScoreDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string LevelName { get; set; }
        public int MinScore { get; set; }
        public int MaxScore { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
