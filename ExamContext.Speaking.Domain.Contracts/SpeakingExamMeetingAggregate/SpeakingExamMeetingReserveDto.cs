using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Speaking.Domain.Contracts.SpeakingExamMeetingAggregate
{
    public class SpeakingExamMeetingReserveDto
    {
        public Guid SpeakingExamMeetingId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid IeltsExamParticipantId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
