using ExamContext.Reading.Aplication.Contracts.ReadingExamAggregate;
using ExamContext.Reading.Facade.Contracts.ReadingExamAggregate;
using Framework.Core.Application;
using Framework.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Facade.ReadingExamAggregate
{
    public class ReadingExamQuestionBlockCommandFacade : FacadeCommandBase, IReadingExamQuestionBlockCommandFacade
    {
        public ReadingExamQuestionBlockCommandFacade(ICommandBus commandBus) : base(commandBus)
        {

        }

        public void AddReadingExamQuestionBlock(AddReadingExamQuestionBlockCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeleteReadingExamQuestionBlock(DeleteReadingExamQuestionBlockCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateReadingExamQuestionBlock(UpdateReadingExamQuestionBlockCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
