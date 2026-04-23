using ExamContext.Reading.Aplication.Contracts.ReadingQuestionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Facade.Contracts.ReadingQuestionAggregate
{
    public interface IReadingQuestionTypeCommandFacade
    {
        void AddReadingQuestionType(AddReadingQuestionTypeCommand command);
        void UpdateReadingQuestionType(UpdateReadingQuestionTypeCommand command);
        void DeleteReadingQuestionType(DeleteReadingQuestionTypeCommand command);
    }
}
