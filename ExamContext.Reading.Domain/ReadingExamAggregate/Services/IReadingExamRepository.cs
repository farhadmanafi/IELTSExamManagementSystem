using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Domain.ReadingExamAggregate.Services
{
    public interface IReadingExamRepository
    {
        void AddReadingExam(ReadingExam readingExam);
        ReadingExam GetReadingExam(Guid readingExamId);
        void UpdateReadingExam(ReadingExam readingExam);
        void DeleteReadingExam(ReadingExam readingExam);
    }
}
