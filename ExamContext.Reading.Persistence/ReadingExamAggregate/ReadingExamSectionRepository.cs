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
    public class ReadingExamSectionRepository : RepositoryBase<ReadingExamSection>, IReadingExamSectionRepository
    {
        public ReadingExamSectionRepository(IDbContext context) : base(context)
        {

        }
        public void AddReadingExamSection(ReadingExamSection readingExamSection)
        {
            Set.Add(readingExamSection);
        }

        public void DeleteReadingExamSection(ReadingExamSection readingExamSection)
        {
            Set.Update(readingExamSection);
        }

        public ReadingExamSection GetReadingExamSection(Guid readingExamSectionId)
        {
            return Set.SingleOrDefault(a => a.Id == readingExamSectionId);
        }

        public void UpdateReadingExamSection(ReadingExamSection readingExamSection)
        {
            Set.Update(readingExamSection);
        }
    }
}
