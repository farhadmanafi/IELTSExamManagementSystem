using ExamContext.OnlinePlacement.Aplication.Contracts.PlacementExamAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Facade.Contracts.PlacementExamAggregate
{
    public interface IPlacementExamFacade
    {
        void AddPlacementExam(AddPlacementExamCommand command);
        void UpdatePlacementExam(UpdatePlacementExamCommand command);
        void DeletePlacementExam(DeletePlacementExamCommand command);
    }
}
