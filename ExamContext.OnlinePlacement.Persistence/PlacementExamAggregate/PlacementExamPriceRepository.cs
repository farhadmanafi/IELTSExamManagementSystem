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
    public class PlacementExamPriceRepository : RepositoryBase<PlacementExamPrice>, IPlacementExamPriceRepository
    {
        public PlacementExamPriceRepository(IDbContext context) : base(context)
        {

        }

        public void AddPlacementExamPrice(PlacementExamPrice placementExamPrice)
        {
            Set.Add(placementExamPrice);
        }

        public PlacementExamPrice GetPlacementExamPrice(Guid id)
        {
            return Set.SingleOrDefault(a => a.Id == id);
        }
        public PlacementExamPrice GetPlacementExamPriceByExamPlacementExamPriceId(Guid placementExamPriceId)
        {
            return Set.SingleOrDefault(a => a.PlacementExamId == placementExamPriceId && a.IsActive == true);
        }

        public PlacementExamPrice GetPlacementExamPriceByExamId(Guid examId)
        {
            return Set.SingleOrDefault(a => a.PlacementExamId == examId);
        }

        public void UpdatePlacementExamPrice(PlacementExamPrice placementExamPrice)
        {
            Set.Update(placementExamPrice);
        }
    }
}
