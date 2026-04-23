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
    public class PlacementQuestionAnswersRepository : RepositoryBase<PlacementQuestionAnswers>, IPlacementQuestionAnswersRepository
    {
        public PlacementQuestionAnswersRepository(IDbContext context) : base(context)
        {

        }
        public void AddPlacementQuestionAnswers(PlacementQuestionAnswers placementQuestionAnswers)
        {
            Set.Add(placementQuestionAnswers);
        }

        public void DeletePlacementQuestionAnswers(PlacementQuestionAnswers placementQuestionAnswers)
        {
            Set.Update(placementQuestionAnswers);
        }

        public PlacementQuestionAnswers GetPlacementQuestionAnswers(Guid placementQuestionAnswersId)
        {
            return Set.SingleOrDefault(a => a.Id == placementQuestionAnswersId);
        }

        public void UpdatePlacementQuestionAnswers(PlacementQuestionAnswers placementQuestionAnswers)
        {
            Set.Update(placementQuestionAnswers);
        }
    }
}
