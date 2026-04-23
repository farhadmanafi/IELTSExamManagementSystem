using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Domain.ReadingQuestionAggregate.Services
{
    public interface IReadingQuestionRepository
    {
        void AddReadingQuestion(ReadingQuestion readingQuestion);
        ReadingQuestion GetReadingQuestion(Guid readingQuestionId);
        void UpdateReadingQuestion(ReadingQuestion readingQuestion);
        void DeleteReadingQuestion(ReadingQuestion readingQuestion);
    }
}
