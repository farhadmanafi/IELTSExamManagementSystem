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
    public class ReadingExamSectionCommandFacade : FacadeCommandBase, IReadingExamSectionCommandFacade
    {
        public ReadingExamSectionCommandFacade(ICommandBus commandBus) : base(commandBus)
        {

        }

        public void AddReadingExamSection(AddReadingExamSectionCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeleteReadingExamSection(DeleteReadingExamSectionCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateReadingExamSection(UpdateReadingExamSectionCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
