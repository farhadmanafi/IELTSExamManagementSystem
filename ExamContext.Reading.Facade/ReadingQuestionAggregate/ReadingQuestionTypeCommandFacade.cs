using ExamContext.Reading.Aplication.Contracts.ReadingQuestionAggregate;
using ExamContext.Reading.Facade.Contracts.ReadingQuestionAggregate;
using Framework.Core.Application;
using Framework.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Facade.ReadingQuestionAggregate
{
    public class ReadingQuestionTypeCommandFacade : FacadeCommandBase, IReadingQuestionTypeCommandFacade
    {
        public ReadingQuestionTypeCommandFacade(ICommandBus commandBus) : base(commandBus)
        {

        }

        public void AddReadingQuestionType(AddReadingQuestionTypeCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeleteReadingQuestionType(DeleteReadingQuestionTypeCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateReadingQuestionType(UpdateReadingQuestionTypeCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
