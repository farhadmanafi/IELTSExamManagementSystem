using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementQuestionAggregate.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementQuestionAggregate
{
    public interface IPlacementQuestionTypeQueryFacade
    {
        IEnumerable<PlacementQuestionTypeQueryFacadeDto> GetPlacementQuestionTypeList();
        PlacementQuestionTypeQueryFacadeDto GetPlacementQuestionType(Guid placementQuestionTypeId);
    }
}
