using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.IeltsAggregarte.DataContracts;
using Framework.Facade;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.IeltsAggregarte
{
    public interface IIeltsExamPriceQueryFacade : IQueryFacade
    {
        IEnumerable<IeltsExamPriceQueryFacadeDto> GetIeltsExamPriceFilteringList(ref DataTableAjaxPostModel filters,Guid id);
        bool IaAnyActiveIeltsExamPriceWithGivenExamId(Guid ieltsExamId);
    }
}
