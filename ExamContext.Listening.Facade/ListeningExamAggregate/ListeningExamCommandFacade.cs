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
    public class ListeningExamCommandFacade : FacadeCommandBase, IListeningExamCommandFacade
    {
        public ListeningExamCommandFacade(ICommandBus commandBus) : base(commandBus)
        {

        }
        public void AddListeningExam(AddListeningExamCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeleteListeningExam(DeleteListeningExamCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateListeningExam(UpdateListeningExamCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
