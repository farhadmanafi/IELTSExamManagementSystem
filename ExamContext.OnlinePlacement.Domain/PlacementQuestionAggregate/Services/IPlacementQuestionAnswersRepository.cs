using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Domain.PlacementQuestionAggregate.Services
{
    public interface IPlacementQuestionAnswersRepository
    {
        void AddPlacementQuestionAnswers(PlacementQuestionAnswers placementQuestionAnswers);
        PlacementQuestionAnswers GetPlacementQuestionAnswers(Guid placementQuestionAnswersId);
        void UpdatePlacementQuestionAnswers(PlacementQuestionAnswers placementQuestionAnswers);
        void DeletePlacementQuestionAnswers(PlacementQuestionAnswers placementQuestionAnswers);
    }
}
