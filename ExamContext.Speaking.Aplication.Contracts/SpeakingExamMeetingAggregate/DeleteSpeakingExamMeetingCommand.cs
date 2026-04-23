using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Speaking.Aplication.Contracts.SpeakingExamMeetingAggregate
{
    public class DeleteSpeakingExamMeetingCommand:Command
    {
        public Guid Id { get; set; }
        public Guid SpeakingExamId { get; set; }
        public Guid IeltsExamParticipantId { get; set; }
        public string Title { get; set; }
        public DateTime MeetingDate { get; set; }
        public string MeetingStartTime { get; set; }
        public string MeetingEndTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
