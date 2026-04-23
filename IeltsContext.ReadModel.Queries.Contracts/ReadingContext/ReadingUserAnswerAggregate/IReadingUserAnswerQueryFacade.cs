using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingUserAnswerAggregate.DataContracts;
using Framework.Facade;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingUserAnswerAggregate
{
    public interface IReadingUserAnswerQueryFacade:IQueryFacade
    {
        IEnumerable<ReadingUserAnswerQueryFacadeDto> GetReadingUserAnswerList();
        ReadingUserAnswerQueryFacadeDto GetReadingUserAnswer(Guid readingUserAnswerId);
        IEnumerable<ReadingUserAnswerQueryFacadeDto> GetReadingExamUserAnswerListByIeltsExamId(ref DataTableAjaxPostModel filters, Guid? readingExamId, Guid? ieltsExamParticipantsId);
        IEnumerable<ReadingUserAnswerQueryFacadeDto> GetReadingExamUserAnswerListUserPanel(ref DataTableAjaxPostModel filters, Guid readingExamId, Guid ieltsExamParticipantsId, Guid customerId);

    }
}
