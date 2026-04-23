using ExamContext.OnlinePlacement.Domain.PlacementUserAnswerAggregate;
using ExamContext.OnlinePlacement.Domain.PlacementUserAnswerAggregate.Services;
using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Persistence.PlacementUserAnswerAggregate
{
    public class PlacementUserAnswerRepository : RepositoryBase<PlacementUserAnswer>, IPlacementUserAnswerRepository
    {
        public PlacementUserAnswerRepository(IDbContext context) : base(context)
        {
                
        }
        public void AddPlacementUserAnswer(PlacementUserAnswer placementUserAnswer)
        {
            Set.Add(placementUserAnswer);
        }

        public void DeletePlacementUserAnswer(PlacementUserAnswer placementUserAnswer)
        {
            Set.Update(placementUserAnswer);
        }

        public PlacementUserAnswer GetPlacementUserAnswer(Guid placementUserAnswerId)
        {
            return Set.SingleOrDefault(a => a.Id == placementUserAnswerId);
        }

        public void UpdatePlacementUserAnswer(PlacementUserAnswer placementUserAnswer)
        {
            Set.Update(placementUserAnswer);
        }
    }
}
