using ExamContext.OnlinePlacement.Aplication.Contracts.ParticipantsAggregate;
using ExamContext.OnlinePlacement.Domain.ParticipantsAggregate.Event;
using ExamContext.OnlinePlacement.Facade.Contracts.ParticipantsAggregate;
using Framework.Core.Application;
using Framework.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Facade.ParticipantsAggregate
{
    public class PlacementExamParticipantsFacade : FacadeCommandBase, IPlacementExamParticipantsFacade
    {
        public PlacementExamParticipantsFacade(ICommandBus commandBus) : base(commandBus)
        {

        }

        public Guid AddPlacementExamParticipants(AddPlacementExamParticipantsCommand command)
        {
            var id = new Guid();
            EventBus.Subscribe<AddPlacementExamParticipantsEvent>(e => id = e.Id);
            CommandBus.Dispatch(command);
            return id;
        }

        public void DeletePlacementExamParticipants(DeletePlacementExamParticipantsCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdatePlacementExamParticipants(UpdatePlacementExamParticipantsCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
