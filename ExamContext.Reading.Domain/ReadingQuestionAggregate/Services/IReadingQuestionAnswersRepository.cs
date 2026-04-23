using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Domain.ReadingQuestionAggregate.Services
{
    public interface IReadingQuestionAnswersRepository
    {
        void AddReadingQuestionAnswers(ReadingQuestionAnswers readingQuestionAnswers);
        ReadingQuestionAnswers GetReadingQuestionAnswers(Guid readingQuestionAnswersId);
        void UpdateReadingQuestionAnswers(ReadingQuestionAnswers readingQuestionAnswers);
        void DeleteReadingQuestionAnswers(ReadingQuestionAnswers readingQuestionAnswers);
    }
}
