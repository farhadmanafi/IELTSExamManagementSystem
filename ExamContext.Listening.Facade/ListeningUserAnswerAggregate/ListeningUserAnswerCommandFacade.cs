using ExamContext.Listening.Aplication.Contracts.ListeningUserAnswerAggregate;
using ExamContext.Listening.Facade.Contracts.ListeningUserAnswerAggregate;
using Framework.Core.Application;
using Framework.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Facade.ListeningUserAnswerAggregate
{
    public class ListeningUserAnswerCommandFacade : FacadeCommandBase, IListeningUserAnswerCommandFacade
    {
        public ListeningUserAnswerCommandFacade(ICommandBus commandBus) : base(commandBus)
        {

        }

        public void AddListeningUserAnswer(AddListeningUserAnswerCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeleteListeningUserAnswer(DeleteListeningUserAnswerCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void ListeningUserAnswer(ListeningUserAnswerCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateListeningUserAnswer(UpdateListeningUserAnswerCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
