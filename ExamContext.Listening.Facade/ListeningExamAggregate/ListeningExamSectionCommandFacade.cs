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
    public class ListeningExamSectionCommandFacade : FacadeCommandBase, IListeningExamSectionCommandFacade
    {
        public ListeningExamSectionCommandFacade(ICommandBus commandBus) : base(commandBus)
        {

        }

        public void AddListeningExamSection(AddListeningExamSectionCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeleteListeningExamSection(DeleteListeningExamSectionCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateListeningExamSection(UpdateListeningExamSectionCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
