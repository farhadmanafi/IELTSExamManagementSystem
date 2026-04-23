using ExamContext.OnlinePlacement.Aplication.Contracts.PlacementUserAnswerAggregate;
using ExamContext.OnlinePlacement.Domain.Contracts.PlacementUserAnswerAggregate.Events;
using ExamContext.OnlinePlacement.Facade.Contracts.PlacementUserAnswerAggregate;
using Framework.Core.Application;
using Framework.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Facade.PlacementUserAnswerAggregate
{
    public class PlacementUserAnswerFacade : FacadeCommandBase, IPlacementUserAnswerFacade
    {
        public PlacementUserAnswerFacade(ICommandBus commandBus) : base(commandBus)
        {

        }
        public Guid AddPlacementUserAnswer(PlacementUserAnswerCommand command)
        {
            var id = new Guid();
            EventBus.Subscribe<AddPlacementUserScoreEvent>(e => id = e.Id);
            CommandBus.Dispatch(command);
            return id;
        }

        public void DeletePlacementUserAnswer(DeletePlacementUserAnswerCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdatePlacementUserAnswer(UpdatePlacementUserAnswerCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
