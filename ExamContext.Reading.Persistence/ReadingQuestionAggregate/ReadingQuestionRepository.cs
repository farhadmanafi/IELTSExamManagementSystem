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
    public class ReadingQuestionRepository : RepositoryBase<ReadingQuestion>, IReadingQuestionRepository
    {
        public ReadingQuestionRepository(IDbContext context) : base(context)
        {

        }

        public void AddReadingQuestion(ReadingQuestion readingQuestion)
        {
            Set.Add(readingQuestion);
        }

        public void DeleteReadingQuestion(ReadingQuestion readingQuestion)
        {
            Set.Update(readingQuestion);
        }

        public ReadingQuestion GetReadingQuestion(Guid readingQuestionId)
        {
            return Set.SingleOrDefault(a => a.Id == readingQuestionId);
        }

        public void UpdateReadingQuestion(ReadingQuestion readingQuestion)
        {
            Set.Update(readingQuestion);
        }
    }
}
