using ExamContext.OnlinePlacement.Aplication.Contracts.ParticipantsAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Facade.Contracts.ParticipantsAggregate
{
    public interface IPlacementExamParticipantsFacade
    {
        Guid AddPlacementExamParticipants(AddPlacementExamParticipantsCommand command);
        void UpdatePlacementExamParticipants(UpdatePlacementExamParticipantsCommand command);
        void DeletePlacementExamParticipants(DeletePlacementExamParticipantsCommand command);
    }
}
