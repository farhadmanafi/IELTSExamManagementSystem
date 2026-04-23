using System;
using System.Collections.Generic;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class SpeakingExamMeeting
    {
        public SpeakingExamMeeting()
        {
            SpeakingExamMeetingReserves = new HashSet<SpeakingExamMeetingReserve>();
        }

        public Guid Id { get; set; }
        public Guid SpeakingExamId { get; set; }
        public string Title { get; set; }
        public DateTime MeetingDate { get; set; }
        public string MeetingStartTime { get; set; }
        public string MeetingEndTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual ICollection<SpeakingExamMeetingReserve> SpeakingExamMeetingReserves { get; set; }
    }
}
