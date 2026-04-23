using ExamContext.Reading.Aplication.Contracts.ReadingUserAnswerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Facade.Contracts.ReadingUserAnswerAggregate
{
    public interface IReadingUserAnswerCommandFacade
    {
        void ReadingUserAnswer(ReadingUserAnswerCommand command);
        void AddReadingUserAnswer(AddReadingUserAnswerCommand command);
        void UpdateReadingUserAnswer(UpdateReadingUserAnswerCommand command);
        void DeleteReadingUserAnswer(DeleteReadingUserAnswerCommand command);
    }
}
