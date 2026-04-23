using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Domain.ReadingUserAnswerAggregate.Services
{
    public interface IReadingUserAnswerRepository
    {
        void AddReadingUserAnswer(ReadingUserAnswer readingUserAnswer);
        ReadingUserAnswer GetReadingUserAnswer(Guid readingUserAnswerId);
        void UpdateReadingUserAnswer(ReadingUserAnswer readingUserAnswer);
        void DeleteReadingUserAnswer(ReadingUserAnswer readingUserAnswer);
    }
}
