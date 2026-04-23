using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Domain.ParticipantsAggregate.Event
{
    public class AddPlacementExamParticipantsEvent
    {
        public AddPlacementExamParticipantsEvent(Guid? id)
        {
            Id = id;
        }
        public Guid? Id { get; private set; }
    }
}
