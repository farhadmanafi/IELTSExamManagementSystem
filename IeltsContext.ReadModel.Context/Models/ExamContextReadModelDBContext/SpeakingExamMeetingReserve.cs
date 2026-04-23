using System;
using System.Collections.Generic;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class SpeakingExamMeetingReserve
    {
        public Guid Id { get; set; }
        public Guid SpeakingExamMeetingId { get; set; }
        public Guid CustomerId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid IeltsExamParticipantId { get; set; }

        public virtual SpeakingExamMeeting SpeakingExamMeeting { get; set; }
    }
}
