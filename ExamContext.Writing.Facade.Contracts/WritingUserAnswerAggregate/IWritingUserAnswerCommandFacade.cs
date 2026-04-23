using ExamContext.Writing.Aplication.Contracts.WritingUserAnswerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Writing.Facade.Contracts.WritingUserAnswerAggregate
{
    public interface IWritingUserAnswerCommandFacade
    {
        void WritingUserAnswer(WritingUserAnswerCommand command);
        void AddWritingUserAnswer(AddWritingUserAnswerCommand command);
        void UpdateWritingUserAnswer(UpdateWritingUserAnswerCommand command);
        void DeleteWritingUserAnswer(DeleteWritingUserAnswerCommand command);
    }
}
