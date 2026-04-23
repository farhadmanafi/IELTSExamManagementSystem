using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Domain.PlacementExamAggregate.Services
{
    public interface IPlacementExamPriceRepository
    {
        void AddPlacementExamPrice(PlacementExamPrice placementExamPrice);
        void UpdatePlacementExamPrice(PlacementExamPrice placementExamPrice);
        PlacementExamPrice GetPlacementExamPriceByExamPlacementExamPriceId(Guid placementExamPriceId);
        PlacementExamPrice GetPlacementExamPrice(Guid id);
        PlacementExamPrice GetPlacementExamPriceByExamId(Guid examId);
    }
}
