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
    public interface IReadingQuestionAnswersQueryFacade:IQueryFacade
    {
        IEnumerable<ReadingQuestionAnswersQueryFacadeDto> GetReadingQuestionAnswersList();
        ReadingQuestionAnswersQueryFacadeDto GetReadingQuestionAnswers(Guid readingQuestionAnswersId);
        IEnumerable<ReadingQuestionAnswersQueryFacadeDto> GetReadingQuestionAnswerListForGridView(ref DataTableAjaxPostModel filters, Guid id);
    }
}
