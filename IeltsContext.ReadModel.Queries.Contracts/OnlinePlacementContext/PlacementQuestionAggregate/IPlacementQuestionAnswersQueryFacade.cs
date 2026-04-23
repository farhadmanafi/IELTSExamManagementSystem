using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementQuestionAggregate.DataContracts;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementQuestionAggregate
{
    public interface IPlacementQuestionAnswersQueryFacade
    {
        IEnumerable<PlacementQuestionAnswersQueryFacadeDto> GetPlacementQuestionAnswersList(ref DataTableAjaxPostModel filters, Guid id);
        PlacementQuestionAnswersQueryFacadeDto GetPlacementQuestionAnswers(Guid placementQuestionAnswersId);
    }
}
