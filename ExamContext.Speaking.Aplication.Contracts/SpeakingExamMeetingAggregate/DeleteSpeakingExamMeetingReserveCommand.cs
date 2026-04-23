using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Speaking.Aplication.Contracts.SpeakingExamMeetingAggregate
{
    public class DeleteSpeakingExamMeetingReserveCommand:Command
    {
        public Guid Id { get; set; }
        public Guid SpeakingExamMeetingId { get; set; }
        public Guid IeltsExamParticipantId { get; set; }
        public Guid CustomerId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
