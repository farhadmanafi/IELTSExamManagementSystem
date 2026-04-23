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
    public class ListeningQuestionAnswersCommandFacade : FacadeCommandBase, IListeningQuestionAnswersCommandFacade
    {
        public ListeningQuestionAnswersCommandFacade(ICommandBus commandBus) : base(commandBus)
        {

        }

        public void AddListeningQuestionAnswers(AddListeningQuestionAnswersCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeleteListeningQuestionAnswers(DeleteListeningQuestionAnswersCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateListeningQuestionAnswers(UpdateListeningQuestionAnswersCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
