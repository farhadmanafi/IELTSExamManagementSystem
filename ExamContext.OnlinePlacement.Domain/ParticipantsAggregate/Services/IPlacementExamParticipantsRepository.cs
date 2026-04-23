using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Domain.ParticipantsAggregate.Services
{
    public interface IPlacementExamParticipantsRepository
    {
        void AddPlacementExamParticipants(PlacementExamParticipants PlacementExamParticipants);
        PlacementExamParticipants GetPlacementExamParticipants(Guid id);
        void UpdatePlacementExamParticipants(PlacementExamParticipants PlacementExamParticipants);
    }
}
