using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementUserAnswerAggregate.DataContracts;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementUserAnswerAggregate
{
    public interface IPlacementUserAnswerQueryFacade
    {
        IEnumerable<PlacementUserAnswerQueryFacadeDto> GetPlacementUserAnswerList(ref DataTableAjaxPostModel filters);
        IEnumerable<PlacementUserAnswerQueryFacadeDto> GetPlacementUserAnswerByPlacementUserScoreIdList(ref DataTableAjaxPostModel filters, Guid placementUserScoreId);
        PlacementUserAnswerQueryFacadeDto GetPlacementUserAnswer(Guid placementUserAnswerId);
        IEnumerable<PlacementUserAnswerQueryFacadeDto> GetPlacementUserAnswerByPlacementUserScoreIdListUserPanel(Guid placementUserScoreId);
    }
}
