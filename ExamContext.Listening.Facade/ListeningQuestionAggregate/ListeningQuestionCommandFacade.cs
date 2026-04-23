using ExamContext.Listening.Aplication.Contracts.ListeningQuestionAggregate;
using ExamContext.Listening.Facade.Contracts.ListeningQuestionAggregate;
using Framework.Core.Application;
using Framework.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Facade.ListeningQuestionAggregate
{
    public class ListeningQuestionCommandFacade : FacadeCommandBase, IListeningQuestionCommandFacade
    {
        public ListeningQuestionCommandFacade(ICommandBus commandBus) : base(commandBus)
        {

        }

        public void AddListeningQuestion(AddListeningQuestionCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeleteListeningQuestion(DeleteListeningQuestionCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateListeningQuestion(UpdateListeningQuestionCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
