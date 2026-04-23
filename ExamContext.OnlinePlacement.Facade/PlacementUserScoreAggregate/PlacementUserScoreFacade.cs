using ExamContext.OnlinePlacement.Aplication.Contracts.PlacementUserScoreAggregate;
using ExamContext.OnlinePlacement.Facade.Contracts.PlacementUserScoreAggregate;
using Framework.Core.Application;
using Framework.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Facade.PlacementUserScoreAggregate
{
    public class PlacementUserScoreFacade : FacadeCommandBase, IPlacementUserScoreFacade
    {
        public PlacementUserScoreFacade(ICommandBus commandBus) : base(commandBus)
        {

        }
        public void AddPlacementUserScore(AddPlacementUserScoreCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeletePlacementUserScore(DeletePlacementUserScoreCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdatePlacementUserScore(UpdatePlacementUserScoreCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdatePlacementUserScoreLevel(UpdatePlacementUserScoreLevelCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
