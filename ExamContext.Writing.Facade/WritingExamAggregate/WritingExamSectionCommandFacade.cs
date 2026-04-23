using ExamContext.Writing.Aplication.Contracts.WritingExamAggregate;
using ExamContext.Writing.Facade.Contracts.WritingExamAggregate;
using Framework.Core.Application;
using Framework.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Writing.Facade.WritingExamAggregate
{
    public class WritingExamSectionCommandFacade : FacadeCommandBase, IWritingExamSectionCommandFacade
    {
        public WritingExamSectionCommandFacade(ICommandBus commandBus) : base(commandBus)
        {

        }

        public void AddWritingExamSection(AddWritingExamSectionCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeleteWritingExamSection(DeleteWritingExamSectionCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateWritingExamSection(UpdateWritingExamSectionCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
