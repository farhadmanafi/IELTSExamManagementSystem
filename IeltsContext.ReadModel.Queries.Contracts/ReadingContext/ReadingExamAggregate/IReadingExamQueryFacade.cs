using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingExamAggregate.DataContracts;
using Framework.Facade;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingExamAggregate
{
    public interface IReadingExamQueryFacade:IQueryFacade
    {
        IEnumerable<ReadingExamQueryFacadeDto> GetReadingExamList();
        IEnumerable<ReadingExamQueryFacadeDto> GetReadingExamByFilteringList(ref DataTableAjaxPostModel filters, Guid examId);
        ReadingExamQueryFacadeDto GetReadingExamById(Guid readingExamId);
        int GetReadingExamCount(Guid id);
        ReadingExamQueryFacadeDto GetReadingExamForUserPanel(Guid id);
        Guid GetIeltsExamByReadingExamId(Guid readingExamId);
    }
}
