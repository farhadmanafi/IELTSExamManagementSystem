using ExamContext.ReadModel.Queries.Contracts.WritingContext.WritingUserAnswerAggregate.DataContracts;
using Framework.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.WritingContext.WritingUserAnswerAggregate
{
    public interface IWritingUserAnswerQueryFacade:IQueryFacade
    {
        IEnumerable<WritingUserAnswerQueryFacadeDto> GetWritingUserAnswerList();
        WritingUserAnswerQueryFacadeDto GetWritingUserAnswer(Guid writingUserAnswerId);
    }
}
