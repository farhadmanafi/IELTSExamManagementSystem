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
    public class ReadingExamQuestionBlockRepository : RepositoryBase<ReadingExamQuestionBlock>, IReadingExamQuestionBlockRepository
    {
        public ReadingExamQuestionBlockRepository(IDbContext context) : base(context)
        {

        }

        public void AddReadingExamQuestionBlock(ReadingExamQuestionBlock readingExamQuestionBlock)
        {
            Set.Add(readingExamQuestionBlock);
        }

        public void DeleteReadingExamQuestionBlock(ReadingExamQuestionBlock readingExamQuestionBlock)
        {
            Set.Update(readingExamQuestionBlock);
        }

        public ReadingExamQuestionBlock GetReadingExamQuestionBlock(Guid readingExamQuestionBlockId)
        {
            return Set.SingleOrDefault(a => a.Id == readingExamQuestionBlockId);
        }

        public void UpdateReadingExamQuestionBlock(ReadingExamQuestionBlock readingExamQuestionBlock)
        {
            Set.Update(readingExamQuestionBlock);
        }
    }
}
