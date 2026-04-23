using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementUserScoreAggregate.DataContracts;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementUserScoreAggregate
{
    public interface IPlacementUserScoreQueryFacade
    {
        IEnumerable<PlacementUserScoreQueryFacadeDto> GetPlacementUserScoreList(ref DataTableAjaxPostModel filters);
        IEnumerable<PlacementUserScoreQueryFacadeDto> GetPlacementUserScoreByIdList(ref DataTableAjaxPostModel filters, Guid onlinePlacemenId);
        PlacementUserScoreQueryFacadeDto GetPlacementUserScore(Guid placementUserScoreId);
        PlacementUserScoreQueryFacadeDto GetPlacementUserScoreByCustomer(Guid customerId,Guid placementExamId);
        IEnumerable<PlacementUserScoreQueryFacadeDto> GetPlacementUserScoreByCustomerIdList(ref DataTableAjaxPostModel filters, Guid customerId);
    }
}
