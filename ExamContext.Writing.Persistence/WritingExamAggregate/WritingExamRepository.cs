using ExamContext.Writing.Domain.WritingExamAggregate;
using ExamContext.Writing.Domain.WritingExamAggregate.Services;
using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Writing.Persistence.WritingExamAggregate
{
    public class WritingExamRepository : RepositoryBase<WritingExam>, IWritingExamRepository
    {
        public WritingExamRepository(IDbContext context) : base(context)
        {

        }

        public void AddWritingExam(WritingExam writingExam)
        {
            Set.Add(writingExam);
        }

        public void DeleteWritingExam(WritingExam writingExam)
        {
            Set.Update(writingExam);
        }

        public WritingExam GetWritingExam(Guid writingExamId)
        {
            return Set.SingleOrDefault(a => a.Id == writingExamId);
        }

        public void UpdateWritingExam(WritingExam writingExam)
        {
            Set.Update(writingExam);
        }
    }
}
