using ExamContext.Speaking.Domain.Contracts.SpeakingExamMeetingAggregate;
using ExamContext.Speaking.Domain.SpeakingExamMeetingAggregate.Exceptions;
using Framework.Core.Domain;
using Framework.Domain;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Speaking.Domain.SpeakingExamMeetingAggregate
{
    public class SpeakingExamMeeting : EntityBase, IAggregateRoot<SpeakingExamMeeting>
    {
        public SpeakingExamMeeting()
        {

        }
        public SpeakingExamMeeting(SpeakingExamMeetingDto dto)
        {
            SpeakingExamId = dto.SpeakingExamId;
            TitleSetter(dto.Title);
            MeetingDate = dto.MeetingDate;
            MeetingStartTime = dto.MeetingStartTime;
            MeetingEndTime = dto.MeetingEndTime;
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
        }

        public Guid SpeakingExamId { get; set; }
        public string Title { get; set; }
        public DateTime MeetingDate { get; set; }
        public string MeetingStartTime { get; set; }
        public string MeetingEndTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<SpeakingExamMeetingReserve> SpeakingExamMeetingReserveList { get; set; }
        public void TitleSetter(string title)
        {
            if (title.Length > SpeakingContextExceptionBoundaries.SpeakingExamTitleMAXLength)
            {
                throw new TitleIsMoreThanMaxLenghException();
            }
            this.Title = title;
        }

        public IEnumerable<Expression<Func<SpeakingExamMeeting, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}
