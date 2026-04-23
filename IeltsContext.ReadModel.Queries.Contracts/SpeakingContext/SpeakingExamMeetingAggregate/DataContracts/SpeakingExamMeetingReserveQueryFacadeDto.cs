using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.SpeakingContext.SpeakingExamMeetingAggregate.DataContracts
{
    public class SpeakingExamMeetingReserveQueryFacadeDto
    {
        public Guid Id { get; set; }
        public Guid SpeakingExamMeetingId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid IeltsExamParticipantId { get; set; }
        public string SpeakingExamMeetingTitle { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
