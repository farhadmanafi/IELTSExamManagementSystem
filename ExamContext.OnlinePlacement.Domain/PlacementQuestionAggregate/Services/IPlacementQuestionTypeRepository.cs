using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Domain.PlacementQuestionAggregate.Services
{
    public interface IPlacementQuestionTypeRepository
    {
        void AddPlacementQuestionType(PlacementQuestionType placementQuestionType);
        PlacementQuestionType GetPlacementQuestionType(Guid placementQuestionTypeId);
        void UpdatePlacementQuestionType(PlacementQuestionType placementQuestionType);
        void DeletePlacementQuestionType(PlacementQuestionType placementQuestionType);
    }
}
