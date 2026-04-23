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
    public class WritingExamCommandFacade : FacadeCommandBase, IWritingExamCommandFacade
    {
        public WritingExamCommandFacade(ICommandBus commandBus) : base(commandBus)
        {

        }

        public void AddWritingExam(AddWritingExamCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeleteWritingExam(DeleteWritingExamCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateWritingExam(UpdateWritingExamCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
