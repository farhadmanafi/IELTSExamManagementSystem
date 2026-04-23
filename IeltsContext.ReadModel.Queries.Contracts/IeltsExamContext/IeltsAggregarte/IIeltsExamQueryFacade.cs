using Framework.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.IeltsAggregarte.DataContracts;
using Ielts.Common.GeneralClass;

namespace ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.IeltsAggregarte.IeltsAggregarte
{    
    public interface IIeltsExamQueryFacade : IQueryFacade
    {
        IeltsExamQueryFacadeDto GetIeltsExamById(Guid id);
        IList<IeltsExamQueryFacadeDto> GetIeltsExamList();
        IEnumerable<IeltsExamQueryFacadeDto> GetIeltsExamFilteringList(ref DataTableAjaxPostModel filters);
        IEnumerable<IeltsExamResultQueryFacadeDto> GetIeltsExamResulFilteringList(ref DataTableAjaxPostModel filters);
        IeltsExamQueryFacadeDto GetIeltsExamByIdForUserpanel(Guid id);
    }
}
