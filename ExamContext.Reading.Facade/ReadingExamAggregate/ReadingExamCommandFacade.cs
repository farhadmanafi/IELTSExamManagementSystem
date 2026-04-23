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
    public class ReadingExamCommandFacade : FacadeCommandBase, IReadingExamCommandFacade
    {
        public ReadingExamCommandFacade(ICommandBus commandBus) : base(commandBus)
        {

        }
        public void AddReadingExam(AddReadingExamCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeleteReadingExam(DeleteReadingExamCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateReadingExam(UpdateReadingExamCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
