using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Domain.Contracts.PlacementUserAnswerAggregate.Events
{
    public class AddPlacementUserScoreEvent
    {
        public AddPlacementUserScoreEvent(Guid? id)
        {
            Id = id;
        }
        public Guid? Id { get; private set; }
    }
}
