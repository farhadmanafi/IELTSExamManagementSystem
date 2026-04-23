using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingQuestionAggregate.DataContracts;
using Framework.Facade;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingQuestionAggregate
{
    public interface IReadingQuestionQueryFacade:IQueryFacade
    {
        IEnumerable<ReadingQuestionQueryFacadeDto> GetReadingQuestionList();
        ReadingQuestionQueryFacadeDto GetReadingQuestion(Guid readingQuestionId);
        IEnumerable<ReadingQuestionQueryFacadeDto> GetReadingQuestionListForGridView(ref DataTableAjaxPostModel filters, Guid id);
        IEnumerable<ReadingQuestionQueryFacadeDto> GetReadingQuestionUserPanelList(Guid readingExamId);
    }
}

