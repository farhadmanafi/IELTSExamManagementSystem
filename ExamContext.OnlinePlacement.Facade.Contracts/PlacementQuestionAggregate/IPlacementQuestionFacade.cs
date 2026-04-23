using ExamContext.OnlinePlacement.Aplication.Contracts.PlacementQuestionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Facade.Contracts.PlacementQuestionAggregate
{
    public interface IPlacementQuestionFacade
    {
        void AddPlacementQuestion(AddPlacementQuestionCommand command);
        void UpdatePlacementQuestion(UpdatePlacementQuestionCommand command);
        void DeletePlacementQuestion(DeletePlacementQuestionCommand command);
    }
}
