using ExamContext.Listening.Aplication.Contracts.ListeningExamAggregate;
using ExamContext.Listening.Facade.Contracts.ListeningExamAggregate;
using Framework.Core.Application;
using Framework.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Facade.ListeningExamAggregate
{
    public class ListeningExamQuestionBlockCommandFacade : FacadeCommandBase, IListeningExamQuestionBlockCommandFacade
    {
        public ListeningExamQuestionBlockCommandFacade(ICommandBus commandBus) : base(commandBus)
        {

        }

        public void AddListeningExamQuestionBlock(AddListeningExamQuestionBlockCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeleteListeningExamQuestionBlock(DeleteListeningExamQuestionBlockCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateListeningExamQuestionBlock(UpdateListeningExamQuestionBlockCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
