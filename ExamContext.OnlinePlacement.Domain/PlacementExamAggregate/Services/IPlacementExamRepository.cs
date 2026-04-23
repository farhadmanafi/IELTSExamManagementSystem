using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Domain.PlacementExamAggregate.Services
{
    public interface IPlacementExamRepository
    {
        void AddPlacementExam(PlacementExam placementExam);
        PlacementExam GetPlacementExam(Guid placementId);
        void UpdatePlacementExam(PlacementExam placementExam);
        void DeletePlacementExam(PlacementExam placementExam);
    }
}
