using ExamContext.Reading.Aplication.Contracts.ReadingUserAnswerAggregate;
using ExamContext.Reading.Facade.Contracts.ReadingUserAnswerAggregate;
using Framework.Core.Application;
using Framework.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Facade.ReadingUserAnswerAggregate
{
    public class ReadingUserAnswerCommandFacade : FacadeCommandBase, IReadingUserAnswerCommandFacade
    {
        public ReadingUserAnswerCommandFacade(ICommandBus commandBus) : base(commandBus)
        {

        }

        public void AddReadingUserAnswer(AddReadingUserAnswerCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeleteReadingUserAnswer(DeleteReadingUserAnswerCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void ReadingUserAnswer(ReadingUserAnswerCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateReadingUserAnswer(UpdateReadingUserAnswerCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
