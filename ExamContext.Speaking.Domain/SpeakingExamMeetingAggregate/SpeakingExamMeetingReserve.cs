using ExamContext.Speaking.Domain.Contracts.SpeakingExamMeetingAggregate;
using Framework.Core.Domain;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Speaking.Domain.SpeakingExamMeetingAggregate
{
    public class SpeakingExamMeetingReserve : EntityBase, IAggregateRoot<SpeakingExamMeetingReserve>
    {
        public SpeakingExamMeetingReserve()
        {

        }
        public SpeakingExamMeetingReserve(SpeakingExamMeetingReserveDto dto)
        {
            SpeakingExamMeetingId = dto.SpeakingExamMeetingId;
            CustomerId = dto.CustomerId;
            IeltsExamParticipantId = dto.IeltsExamParticipantId;
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
        }
        public Guid SpeakingExamMeetingId { get; set; }
        [ForeignKey("SpeakingExamMeetingId")]
        public SpeakingExamMeeting currentSpeakingExamMeeting { get; set; }
        public Guid CustomerId { get; set; }
        public Guid IeltsExamParticipantId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public IEnumerable<Expression<Func<SpeakingExamMeetingReserve, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}
