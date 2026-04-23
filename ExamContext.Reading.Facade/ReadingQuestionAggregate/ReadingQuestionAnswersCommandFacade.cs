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
    public class ReadingQuestionAnswersCommandFacade : FacadeCommandBase, IReadingQuestionAnswersCommandFacade
    {
        public ReadingQuestionAnswersCommandFacade(ICommandBus commandBus) : base(commandBus)
        {

        }

        public void AddReadingQuestionAnswers(AddReadingQuestionAnswersCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeleteReadingQuestionAnswers(DeleteReadingQuestionAnswersCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateReadingQuestionAnswers(UpdateReadingQuestionAnswersCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
