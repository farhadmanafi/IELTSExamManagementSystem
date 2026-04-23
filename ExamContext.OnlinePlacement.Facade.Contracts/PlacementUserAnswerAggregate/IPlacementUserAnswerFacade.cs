using ExamContext.OnlinePlacement.Aplication.Contracts.PlacementUserAnswerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Facade.Contracts.PlacementUserAnswerAggregate
{
    public interface IPlacementUserAnswerFacade
    {
        Guid AddPlacementUserAnswer(PlacementUserAnswerCommand command);
        void UpdatePlacementUserAnswer(UpdatePlacementUserAnswerCommand command);
        void DeletePlacementUserAnswer(DeletePlacementUserAnswerCommand command);
    }
}
