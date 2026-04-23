using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Domain.PlacementUserAnswerAggregate.Services
{
    public interface IPlacementUserAnswerRepository
    {
        void AddPlacementUserAnswer(PlacementUserAnswer placementUserAnswer);
        PlacementUserAnswer GetPlacementUserAnswer(Guid placementUserAnswerId);
        void UpdatePlacementUserAnswer(PlacementUserAnswer placementUserAnswer);
        void DeletePlacementUserAnswer(PlacementUserAnswer placementUserAnswer);
    }
}
