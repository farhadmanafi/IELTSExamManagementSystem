using ExamContext.Writing.Aplication.Contracts.WritingUserAnswerAggregate;
using ExamContext.Writing.Facade.Contracts.WritingUserAnswerAggregate;
using Framework.Core.Application;
using Framework.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Writing.Facade.WritingUserAnswerAggregate
{
    public class WritingUserAnswerCommandFacade : FacadeCommandBase, IWritingUserAnswerCommandFacade
    {
        public WritingUserAnswerCommandFacade(ICommandBus commandBus) : base(commandBus)
        {

        }

        public void AddWritingUserAnswer(AddWritingUserAnswerCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeleteWritingUserAnswer(DeleteWritingUserAnswerCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateWritingUserAnswer(UpdateWritingUserAnswerCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void WritingUserAnswer(WritingUserAnswerCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
