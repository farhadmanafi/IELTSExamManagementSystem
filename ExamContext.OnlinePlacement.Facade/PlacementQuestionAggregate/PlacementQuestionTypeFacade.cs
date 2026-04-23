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
    public class PlacementQuestionTypeFacade : FacadeCommandBase, IPlacementQuestionTypeFacade
    {
        public PlacementQuestionTypeFacade(ICommandBus commandBus) : base(commandBus)
        {

        }
        public void AddPlacementQuestionType(AddPlacementQuestionTypeCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeletePlacementQuestionType(DeletePlacementQuestionTypeCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdatePlacementQuestionType(UpdatePlacementQuestionTypeCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
