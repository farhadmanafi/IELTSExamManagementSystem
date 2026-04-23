using ExamContext.OnlinePlacement.Aplication.Contracts.PlacementQuestionAggregate;
using ExamContext.OnlinePlacement.Facade.Contracts.PlacementQuestionAggregate;
using Framework.Core.Application;
using Framework.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Facade.PlacementQuestionAggregate
{
    public class PlacementQuestionFacade : FacadeCommandBase, IPlacementQuestionFacade
    {
        public PlacementQuestionFacade(ICommandBus commandBus) : base(commandBus)
        {

        }
        public void AddPlacementQuestion(AddPlacementQuestionCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeletePlacementQuestion(DeletePlacementQuestionCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdatePlacementQuestion(UpdatePlacementQuestionCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
