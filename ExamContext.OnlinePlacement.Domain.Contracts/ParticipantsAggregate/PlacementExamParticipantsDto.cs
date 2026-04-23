using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Domain.Contracts.ParticipantsAggregate
{
    public class PlacementExamParticipantsDto
    {
        public Guid CustomerId { get; set; }
        public Guid PlacementExamId { get; set; }
        public Guid PlacementExamPriceId { get; set; }
        public int PlacementExamOrederNumber { get; set; }
        public DateTime RegisterDate { get; set; }
        public Guid PlacementExamParticipantsStatusId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
