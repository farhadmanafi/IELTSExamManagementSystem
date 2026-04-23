using ExamContext.OnlinePlacement.Domain.PlacementExamAggregate;
using ExamContext.OnlinePlacement.Domain.PlacementExamAggregate.Services;
using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Persistence.PlacementExamAggregate
{
    public class PlacementExamRepository : RepositoryBase<PlacementExam>, IPlacementExamRepository
    {
        public PlacementExamRepository(IDbContext context) : base(context)
        {

        }
        public void AddPlacementExam(PlacementExam placementExam)
        {
            Set.Add(placementExam);
        }

        public void DeletePlacementExam(PlacementExam placementExam)
        {
            Set.Update(placementExam);
        }

        public PlacementExam GetPlacementExam(Guid placementId)
        {
            return Set.SingleOrDefault(a => a.Id == placementId);
        }

        public void UpdatePlacementExam(PlacementExam placementExam)
        {
            Set.Update(placementExam);
        }
    }
}
