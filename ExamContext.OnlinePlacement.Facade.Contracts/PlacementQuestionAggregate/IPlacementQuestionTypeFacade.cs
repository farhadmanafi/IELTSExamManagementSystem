using ExamContext.OnlinePlacement.Aplication.Contracts.PlacementQuestionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Facade.Contracts.PlacementQuestionAggregate
{
    public interface IPlacementQuestionTypeFacade
    {
        void AddPlacementQuestionType(AddPlacementQuestionTypeCommand command);
        void UpdatePlacementQuestionType(UpdatePlacementQuestionTypeCommand command);
        void DeletePlacementQuestionType(DeletePlacementQuestionTypeCommand command);
    }
}
