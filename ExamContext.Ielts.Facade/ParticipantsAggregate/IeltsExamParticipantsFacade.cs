using ExamContext.Ielts.Aplication.Contracts.ParticipantsAggregate;
using ExamContext.Ielts.Domain.ParticipantsAggregate.Event;
using ExamContext.Ielts.Facade.Contracts.ParticipantsAggregate;
using Framework.Core.Application;
using Framework.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Facade.ParticipantsAggregate
{
    public class IeltsExamParticipantsFacade : FacadeCommandBase, IIeltsExamParticipantsFacade
    {
        public IeltsExamParticipantsFacade(ICommandBus commandBus) : base(commandBus)
        {

        }

        public Guid AddIeltsExamParticipants(AddIeltsExamParticipantsCommand command)
        {
            var id = new Guid();
            EventBus.Subscribe<AddIeltsExamParticipantsEvent>(e => id = e.Id);
            CommandBus.Dispatch(command);
            return id;
        }

        public void DeleteIeltsExamParticipants(DeleteIeltsExamParticipantsCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateIeltsExamParticipants(UpdateIeltsExamParticipantsCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
