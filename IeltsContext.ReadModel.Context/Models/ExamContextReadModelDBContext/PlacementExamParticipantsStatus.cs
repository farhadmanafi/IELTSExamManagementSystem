using System;
using System.Collections.Generic;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class PlacementExamParticipantsStatus
    {
        public PlacementExamParticipantsStatus()
        {
            PlacementExamParticipants = new HashSet<PlacementExamParticipant>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual ICollection<PlacementExamParticipant> PlacementExamParticipants { get; set; }
    }
}
