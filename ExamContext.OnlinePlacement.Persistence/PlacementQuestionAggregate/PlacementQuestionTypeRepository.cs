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
    public class PlacementQuestionTypeRepository : RepositoryBase<PlacementQuestionType>, IPlacementQuestionTypeRepository
    {
        public PlacementQuestionTypeRepository(IDbContext context) : base(context)
        {

        }
        public void AddPlacementQuestionType(PlacementQuestionType placementQuestionType)
        {
            Set.Add(placementQuestionType);
        }

        public void DeletePlacementQuestionType(PlacementQuestionType placementQuestionType)
        {
            Set.Update(placementQuestionType);
        }

        public PlacementQuestionType GetPlacementQuestionType(Guid placementQuestionTypeId)
        {
            return Set.SingleOrDefault(a => a.Id == placementQuestionTypeId);
        }

        public void UpdatePlacementQuestionType(PlacementQuestionType placementQuestionType)
        {
            Set.Update(placementQuestionType);
        }
    }
}
