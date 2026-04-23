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
    public class PlacementQuestionAnswersFacade : FacadeCommandBase, IPlacementQuestionAnswersFacade
    {
        public PlacementQuestionAnswersFacade(ICommandBus commandBus) : base(commandBus)
        {

        }
        public void AddPlacementQuestionAnswers(AddPlacementQuestionAnswersCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeletePlacementQuestionAnswers(DeletePlacementQuestionAnswersCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdatePlacementQuestionAnswers(UpdatePlacementQuestionAnswersCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
