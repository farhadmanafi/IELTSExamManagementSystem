using ExamContext.Reading.Aplication.Contracts.ReadingQuestionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Facade.Contracts.ReadingQuestionAggregate
{
    public interface IReadingQuestionCommandFacade
    {
        void AddReadingQuestion(AddReadingQuestionCommand command);
        void UpdateReadingQuestion(UpdateReadingQuestionCommand command);
        void DeleteReadingQuestion(DeleteReadingQuestionCommand command);
    }
}
