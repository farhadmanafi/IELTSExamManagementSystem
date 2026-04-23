using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Domain.ReadingExamAggregate.Services
{
    public interface IReadingExamSectionRepository
    {
        void AddReadingExamSection(ReadingExamSection readingExamSection);
        ReadingExamSection GetReadingExamSection(Guid readingExamSectionId);
        void UpdateReadingExamSection(ReadingExamSection readingExamSection);
        void DeleteReadingExamSection(ReadingExamSection readingExamSection);
    }
}
