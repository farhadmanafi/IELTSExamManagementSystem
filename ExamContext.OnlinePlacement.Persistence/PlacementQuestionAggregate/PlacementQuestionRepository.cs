using ExamContext.OnlinePlacement.Domain.PlacementQuestionAggregate;
using ExamContext.OnlinePlacement.Domain.PlacementQuestionAggregate.Services;
using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Persistence.PlacementQuestionAggregate
{
    public class PlacementQuestionRepository : RepositoryBase<PlacementQuestion>, IPlacementQuestionRepository
    {
        public PlacementQuestionRepository(IDbContext context) : base(context)
        {

        }
        public void AddPlacementQuestion(PlacementQuestion placementQuestion)
        {
            Set.Add(placementQuestion);
        }

        public void DeletePlacementQuestion(PlacementQuestion placementQuestion)
        {
            Set.Update(placementQuestion);
        }

        public PlacementQuestion GetPlacementQuestion(Guid placementQuestionId)
        {
            return Set.SingleOrDefault(a => a.Id == placementQuestionId);
        }

        public void UpdatePlacementQuestion(PlacementQuestion placementQuestion)
        {
            Set.Update(placementQuestion);
        }
    }
}
