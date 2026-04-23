using ExamContext.Reading.Domain.ReadingUserAnswerAggregate;
using ExamContext.Reading.Domain.ReadingUserAnswerAggregate.Services;
using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Persistence.ReadingUserAnswerAggregate
{
    public class ReadingUserAnswerRepository : RepositoryBase<ReadingUserAnswer>, IReadingUserAnswerRepository
    {
        public ReadingUserAnswerRepository(IDbContext context) : base(context)
        {

        }

        public void AddReadingUserAnswer(ReadingUserAnswer readingUserAnswer)
        {
            Set.Add(readingUserAnswer);
        }

        public void DeleteReadingUserAnswer(ReadingUserAnswer readingUserAnswer)
        {
            Set.Update(readingUserAnswer);
        }

        public ReadingUserAnswer GetReadingUserAnswer(Guid readingUserAnswerId)
        {
            return Set.SingleOrDefault(a => a.Id == readingUserAnswerId);
        }

        public void UpdateReadingUserAnswer(ReadingUserAnswer readingUserAnswer)
        {
            Set.Update(readingUserAnswer);
        }
    }
}
