using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementExamAggregate.DataContracts;
using Framework.Facade;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementExamAggregate
{
    public interface IPlacementExamQueryFacade : IQueryFacade
    {
        IEnumerable<PlacementExamQueryFacadeDto> GetPlacementExamList(ref DataTableAjaxPostModel filters);
        IEnumerable<PlacementExamQueryFacadeDto> GetPlacementExamActiveList();
        PlacementExamQueryFacadeDto GetPlacementExam(Guid placementExamId);
        PlacementExamQueryFacadeDto GetPlacementExamForUserpanel(Guid placementExamId);

    }
}
