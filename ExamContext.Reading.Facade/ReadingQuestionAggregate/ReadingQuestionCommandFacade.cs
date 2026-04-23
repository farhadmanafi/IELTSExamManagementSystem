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
    public class ReadingQuestionCommandFacade : FacadeCommandBase, IReadingQuestionCommandFacade
    {
        public ReadingQuestionCommandFacade(ICommandBus commandBus) : base(commandBus)
        {

        }

        public void AddReadingQuestion(AddReadingQuestionCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeleteReadingQuestion(DeleteReadingQuestionCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateReadingQuestion(UpdateReadingQuestionCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
