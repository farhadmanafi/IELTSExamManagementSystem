using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Domain.ReadingQuestionAggregate.Services
{
    public interface IReadingQuestionTypeRepository
    {
        void AddReadingQuestionType(ReadingQuestionType readingQuestionType);
        ReadingQuestionType GetReadingQuestionType(Guid readingQuestionTypeId);
        void UpdateReadingQuestionType(ReadingQuestionType readingQuestionType);
        void DeleteReadingQuestionType(ReadingQuestionType readingQuestionType);
    }
}
