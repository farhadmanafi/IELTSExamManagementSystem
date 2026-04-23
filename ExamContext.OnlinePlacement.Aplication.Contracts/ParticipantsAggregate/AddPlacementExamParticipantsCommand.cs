using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Aplication.Contracts.ParticipantsAggregate
{
    public class AddPlacementExamParticipantsCommand:Command
    {
        public Guid CustomerId { get; set; }
        public Guid PlacementExamId { get; set; }
        public Guid PlacementExamPriceId { get; set; }
        public int PlacementExamOrederNumber { get; set; }
        public Guid PlacementExamParticipantsStatusId { get; set; }
        public DateTime RegisterDate { get; set; }

    }
}
