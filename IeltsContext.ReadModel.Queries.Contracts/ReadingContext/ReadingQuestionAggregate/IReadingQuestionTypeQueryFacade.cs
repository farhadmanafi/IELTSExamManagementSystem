using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingQuestionAggregate.DataContracts;
using Framework.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingQuestionAggregate
{
    public interface IReadingQuestionTypeQueryFacade : IQueryFacade
    {
        IEnumerable<ReadingQuestionTypeQueryFacadeDto> GetReadingQuestionTypeList();
        ReadingQuestionTypeQueryFacadeDto GetReadingQuestionType(Guid readingQuestionTypeId);
    }
}
