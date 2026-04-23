using ExamContext.OnlinePlacement.Aplication.Contracts.PlacementQuestionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Facade.Contracts.PlacementQuestionAggregate
{
    public interface IPlacementQuestionAnswersFacade
    {
        void AddPlacementQuestionAnswers(AddPlacementQuestionAnswersCommand command);
        void UpdatePlacementQuestionAnswers(UpdatePlacementQuestionAnswersCommand command);
        void DeletePlacementQuestionAnswers(DeletePlacementQuestionAnswersCommand command);
    }
}
