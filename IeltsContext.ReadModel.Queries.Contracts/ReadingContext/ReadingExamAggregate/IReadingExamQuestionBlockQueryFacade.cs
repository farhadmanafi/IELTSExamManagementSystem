using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingExamAggregate.DataContracts;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingExamAggregate
{
    public interface IReadingExamQuestionBlockQueryFacade
    {
        IEnumerable<ReadingExamQuestionBlockQueryFacadeDto> GetReadingExamQuestionBlockList();
        IEnumerable<ReadingExamQuestionBlockQueryFacadeDto> GetReadingExamQuestionBlocListByReadingSectionId(Guid listeningExamSectionId);
        IEnumerable<ReadingExamQuestionBlockQueryFacadeDto> GetReadingExamQuestionBlockListForGridView(ref DataTableAjaxPostModel filters, Guid id);
        ReadingExamQuestionBlockQueryFacadeDto GetReadingExamQuestionBlock(Guid readingExamQuestionBlockId);
    }
}
