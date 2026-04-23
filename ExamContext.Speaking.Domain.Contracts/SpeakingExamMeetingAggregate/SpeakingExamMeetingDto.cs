using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Speaking.Domain.Contracts.SpeakingExamMeetingAggregate
{
    public class SpeakingExamMeetingDto
    {
        public Guid SpeakingExamId { get; set; }
        public string Title { get; set; }
        public DateTime MeetingDate { get; set; }
        public string MeetingStartTime { get; set; }
        public string MeetingEndTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
