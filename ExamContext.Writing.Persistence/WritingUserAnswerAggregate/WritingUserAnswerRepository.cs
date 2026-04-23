using ExamContext.Writing.Domain.WritingUserAnswerAggregate;
using ExamContext.Writing.Domain.WritingUserAnswerAggregate.Services;
using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Writing.Persistence.WritingUserTextAggregate
{
    public class WritingUserAnswerRepository : RepositoryBase<WritingUserAnswer>, IWritingUserAnswerRepository
    {
        public WritingUserAnswerRepository(IDbContext context) : base(context)
        {

        }

        public void AddWritingUserAnswer(WritingUserAnswer writingUserAnswer)
        {
            Set.Add(writingUserAnswer);
        }

        public void DeleteWritingUserAnswer(WritingUserAnswer writingUserAnswer)
        {
            Set.Update(writingUserAnswer);
        }

        public WritingUserAnswer GetWritingUserAnswer(Guid writingUserAnswerId)
        {
            return Set.SingleOrDefault(a => a.Id == writingUserAnswerId);
        }

        public void UpdateWritingUserAnswer(WritingUserAnswer writingUserAnswer)
        {
            Set.Update(writingUserAnswer);
        }
    }
}
