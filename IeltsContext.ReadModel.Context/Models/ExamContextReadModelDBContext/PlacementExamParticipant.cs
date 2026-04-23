using System;
using System.Collections.Generic;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class PlacementExamParticipant
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid PlacementExamId { get; set; }
        public Guid PlacementExamPriceId { get; set; }
        public int PlacementExamOrederNumber { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Guid PlacementExamParticipantsStatusId { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual PlacementExamParticipantsStatus PlacementExamParticipantsStatus { get; set; }
    }
}
