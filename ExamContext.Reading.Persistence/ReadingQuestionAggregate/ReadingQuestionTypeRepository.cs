using ExamContext.Reading.Domain.ReadingQuestionAggregate;
using ExamContext.Reading.Domain.ReadingQuestionAggregate.Services;
using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Persistence.ReadingQuestionAggregate
{
    public class ReadingQuestionTypeRepository : RepositoryBase<ReadingQuestionType>, IReadingQuestionTypeRepository
    {
        public ReadingQuestionTypeRepository(IDbContext context) : base(context)
        {

        }

        public void AddReadingQuestionType(ReadingQuestionType readingQuestionType)
        {
            Set.Add(readingQuestionType);
        }

        public void DeleteReadingQuestionType(ReadingQuestionType readingQuestionType)
        {
            Set.Update(readingQuestionType);
        }

        public ReadingQuestionType GetReadingQuestionType(Guid readingQuestionTypeId)
        {
            return Set.SingleOrDefault(a => a.Id == readingQuestionTypeId);
        }

        public void UpdateReadingQuestionType(ReadingQuestionType readingQuestionType)
        {
            Set.Update(readingQuestionType);
        }
    }
}
