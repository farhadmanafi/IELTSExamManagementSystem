using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.SpeakingContext.SpeakingExamMeetingAggregate.DataContracts
{
    public class SpeakingExamMeetingQueryFacadeDto
    {
        public Guid Id { get; set; }
        public Guid SpeakingExamId { get; set; }
        public Guid IeltsExamParticipantId { get; set; }
        public string Title { get; set; }
        public DateTime MeetingDate { get; set; }
        public string MeetingDate_Persian { get; set; }
        public string MeetingStartTime { get; set; }
        public string MeetingEndTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
