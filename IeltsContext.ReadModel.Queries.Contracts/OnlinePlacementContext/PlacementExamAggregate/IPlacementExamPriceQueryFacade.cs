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
    public interface IPlacementExamPriceQueryFacade : IQueryFacade
    {
        IEnumerable<PlacementExamPriceQueryFacadeDto> GetPlacementExamPriceFilteringList(ref DataTableAjaxPostModel filters, Guid id);
        bool IaAnyActivePlacementExamPriceWithGivenExamId(Guid placementExamId);
    }
}
