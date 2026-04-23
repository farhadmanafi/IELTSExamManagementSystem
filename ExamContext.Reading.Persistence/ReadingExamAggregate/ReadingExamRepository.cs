using ExamContext.Reading.Domain.ReadingExamAggregate;
using ExamContext.Reading.Domain.ReadingExamAggregate.Services;
using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Persistence.ReadingExamAggregate
{
    public class ReadingExamRepository : RepositoryBase<ReadingExam>, IReadingExamRepository
    {
        public ReadingExamRepository(IDbContext context) : base(context)
        {

        }

        public void AddReadingExam(ReadingExam readingExam)
        {
            Set.Add(readingExam);
        }

        public void DeleteReadingExam(ReadingExam readingExam)
        {
            Set.Update(readingExam);
        }

        public ReadingExam GetReadingExam(Guid readingExamId)
        {
            return Set.SingleOrDefault(a => a.Id == readingExamId);
        }

        public void UpdateReadingExam(ReadingExam readingExam)
        {
            Set.Update(readingExam);
        }
    }
}
