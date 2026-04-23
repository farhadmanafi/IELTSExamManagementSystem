using ExamContext.OnlinePlacement.Domain.PlacementQuestionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Domain.PlacementUserScoreAggregate.Services
{
    public interface IPlacementUserScoreRepository
    {
        void AddPlacementUserScore(PlacementUserScore placementUserScore);
        PlacementUserScore GetPlacementUserScore(Guid placementUserScoreId);
        void UpdatePlacementUserScore(PlacementUserScore placementUserScore);
        void DeletePlacementUserScore(PlacementUserScore placementUserScore);
    }
}
