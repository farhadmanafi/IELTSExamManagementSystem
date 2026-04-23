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
    public class WritingExamSectionRepository : RepositoryBase<WritingExamSection>, IWritingExamSectionRepository
    {
        public WritingExamSectionRepository(IDbContext context) : base(context)
        {

        }

        public void AddWritingExamSection(WritingExamSection writingExamSection)
        {
            Set.Add(writingExamSection);
        }

        public void DeleteWritingExamSection(WritingExamSection writingExamSection)
        {
            Set.Update(writingExamSection);
        }

        public WritingExamSection GetWritingExamSection(Guid writingExamSectionId)
        {
            return Set.SingleOrDefault(a => a.Id == writingExamSectionId);
        }

        public void UpdateWritingExamSection(WritingExamSection writingExamSection)
        {
            Set.Update(writingExamSection);
        }
    }
}
