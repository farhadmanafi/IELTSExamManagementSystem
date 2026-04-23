using ExamContext.OnlinePlacement.Aplication.Contracts.PlacementUserScoreAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Facade.Contracts.PlacementUserScoreAggregate
{
    public interface IPlacementUserScoreFacade
    {
        void AddPlacementUserScore(AddPlacementUserScoreCommand command);
        void UpdatePlacementUserScore(UpdatePlacementUserScoreCommand command);
        void UpdatePlacementUserScoreLevel(UpdatePlacementUserScoreLevelCommand command);
        void DeletePlacementUserScore(DeletePlacementUserScoreCommand command);
    }
}
