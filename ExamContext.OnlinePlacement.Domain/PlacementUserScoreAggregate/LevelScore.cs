using ExamContext.OnlinePlacement.Domain.Contracts.PlacementUserScoreAggregate;
using Framework.Core.Domain;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Domain.PlacementUserScoreAggregate
{
    public class LevelScore : EntityBase//, IAggregateRoot<LevelScore>
    {
        public LevelScore()
        {

        }
        public LevelScore(LevelScoreDto dto)
        {
            Title = dto.Title;
            Description = dto.Description;
            LevelName = dto.LevelName;
            MinScore = dto.MinScore;
            MaxScore = dto.MaxScore;
            OrderNo = dto.OrderNo;
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public string LevelName { get; set; }
        public int MinScore { get; set; }
        public int MaxScore { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<PlacementUserScore> PlacementUserScoreList { get; set; }


    }
}
