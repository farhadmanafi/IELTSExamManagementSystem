using ExamContext.OnlinePlacement.Domain.Contracts.PlacementUserAnswerAggregate.Events;
using ExamContext.OnlinePlacement.Domain.Contracts.PlacementUserScoreAggregate;
using Framework.Core.Domain;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Domain.PlacementUserScoreAggregate
{
    public class PlacementUserScore : EntityBase, IAggregateRoot<PlacementUserScore>
    {
        public PlacementUserScore()
        {

        }
        public PlacementUserScore(PlacementUserScoreDto dto)
        {
            PlacementExamId = dto.PlacementExamId;
            CustomerId = dto.CustomerId;
            LevelScoreId = dto.LevelScoreId;
            ExamDate = dto.ExamDate;
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;

            EventBus.Publish(new AddPlacementUserScoreEvent(Id));
        }
        public Guid PlacementExamId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime ExamDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public Guid LevelScoreId { get; set; }
        [ForeignKey("LevelScoreId")]
        public LevelScore LevelScoreCurrent { get; set; }

        public IEnumerable<Expression<Func<PlacementUserScore, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}
