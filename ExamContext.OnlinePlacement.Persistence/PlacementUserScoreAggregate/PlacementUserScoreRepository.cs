using ExamContext.OnlinePlacement.Domain.PlacementQuestionAggregate;
using ExamContext.OnlinePlacement.Domain.PlacementUserScoreAggregate;
using ExamContext.OnlinePlacement.Domain.PlacementUserScoreAggregate.Services;
using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Persistence.PlacementUserScoreAggregate
{
    public class PlacementUserScoreRepository : RepositoryBase<PlacementUserScore>, IPlacementUserScoreRepository
    {
        public PlacementUserScoreRepository(IDbContext context) : base(context)
        {

        }

        public void AddPlacementUserScore(PlacementUserScore placementUserScore)
        {
            Set.Add(placementUserScore);
        }

        public void DeletePlacementUserScore(PlacementUserScore placementUserScore)
        {
            Set.Update(placementUserScore);
        }

        public PlacementUserScore GetPlacementUserScore(Guid placementUserScoreId)
        {
            return Set.SingleOrDefault(a => a.Id == placementUserScoreId);
        }

        public void UpdatePlacementUserScore(PlacementUserScore placementUserScore)
        {
            Set.Update(placementUserScore);
        }
    }
}
