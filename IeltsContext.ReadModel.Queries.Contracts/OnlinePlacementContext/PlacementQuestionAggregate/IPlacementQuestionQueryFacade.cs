using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementQuestionAggregate.DataContracts;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementQuestionAggregate
{
    public interface IPlacementQuestionQueryFacade
    {
        IEnumerable<PlacementQuestionQueryFacadeDto> GetPlacementQuestionList(ref DataTableAjaxPostModel filters, Guid id);
        PlacementQuestionQueryFacadeDto GetPlacementQuestion(Guid PlacementQuestionId);
        IEnumerable<PlacementQuestionQueryFacadeDto> GetPlacementQuestionByPlacementExamList(Guid placementExamId);
        IEnumerable<PlacementQuestionQueryFacadeDto> GetPlacementQuestionByPlacementExamUserPanelList(Guid placementExamId);
    }
}
