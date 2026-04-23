using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Domain.PlacementQuestionAggregate.Services
{
    public interface IPlacementQuestionRepository
    {
        void AddPlacementQuestion(PlacementQuestion placementQuestion);
        PlacementQuestion GetPlacementQuestion(Guid placementQuestionId);
        void UpdatePlacementQuestion(PlacementQuestion placementQuestion);
        void DeletePlacementQuestion(PlacementQuestion placementQuestion);
    }
}
