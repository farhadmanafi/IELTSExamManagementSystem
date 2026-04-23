using ExamContext.Reading.Aplication.Contracts.ReadingQuestionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Facade.Contracts.ReadingQuestionAggregate
{
    public interface IReadingQuestionAnswersCommandFacade
    {
        void AddReadingQuestionAnswers(AddReadingQuestionAnswersCommand command);
        void UpdateReadingQuestionAnswers(UpdateReadingQuestionAnswersCommand command);
        void DeleteReadingQuestionAnswers(DeleteReadingQuestionAnswersCommand command);
    }
}
