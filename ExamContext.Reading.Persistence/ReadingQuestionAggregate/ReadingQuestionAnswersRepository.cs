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
    public class ReadingQuestionAnswersRepository : RepositoryBase<ReadingQuestionAnswers>, IReadingQuestionAnswersRepository
    {
        public ReadingQuestionAnswersRepository(IDbContext context) : base(context)
        {

        }

        public void AddReadingQuestionAnswers(ReadingQuestionAnswers readingQuestionAnswers)
        {
            Set.Add(readingQuestionAnswers);
        }

        public void DeleteReadingQuestionAnswers(ReadingQuestionAnswers readingQuestionAnswers)
        {
            Set.Update(readingQuestionAnswers);
        }

        public ReadingQuestionAnswers GetReadingQuestionAnswers(Guid readingQuestionAnswersId)
        {
            return Set.SingleOrDefault(a => a.Id == readingQuestionAnswersId);
        }

        public void UpdateReadingQuestionAnswers(ReadingQuestionAnswers readingQuestionAnswers)
        {
            Set.Update(readingQuestionAnswers);
        }
    }
}
