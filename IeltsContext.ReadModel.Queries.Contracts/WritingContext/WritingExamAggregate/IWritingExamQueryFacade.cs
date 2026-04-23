using ExamContext.ReadModel.Queries.Contracts.WritingContext.WritingExamAggregate.DataContracts;
using Framework.Facade;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.WritingContext.WritingExamAggregate
{
    public interface IWritingExamQueryFacade:IQueryFacade
    {
        IEnumerable<WritingExamQueryFacadeDto> GetWritingExamList();
        WritingExamQueryFacadeDto GetWritingExamById(Guid writingExamId);
        IEnumerable<WritingExamQueryFacadeDto> GetWritingExamByFilteringList(ref DataTableAjaxPostModel filters, Guid examId);
        int GetWritingExamCount(Guid id);
        Guid GetIeltsExamByWritingExamId(Guid writingExamId);
        WritingExamQueryFacadeDto GetWritingExamForUserPanel(Guid id);
    }
}
