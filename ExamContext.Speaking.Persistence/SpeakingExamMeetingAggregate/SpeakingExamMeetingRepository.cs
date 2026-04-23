using ExamContext.Speaking.Domain.SpeakingExamMeetingAggregate;
using ExamContext.Speaking.Domain.SpeakingExamMeetingAggregate.Services;
using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Speaking.Persistence.SpeakingExamMeetingAggregate
{
    public class SpeakingExamMeetingRepository : RepositoryBase<SpeakingExamMeeting>, ISpeakingExamMeetingRepository
    {
        public SpeakingExamMeetingRepository(IDbContext context) : base(context)
        {

        }

        public void AddSpeakingExamMeeting(SpeakingExamMeeting speakingExamMeeting)
        {
            Set.Add(speakingExamMeeting);
        }

        public void DeleteSpeakingExamMeeting(SpeakingExamMeeting speakingExamMeeting)
        {
            Set.Update(speakingExamMeeting);
        }

        public SpeakingExamMeeting GetSpeakingExamMeeting(Guid speakingExamMeetingId)
        {
            return Set.SingleOrDefault(a => a.Id == speakingExamMeetingId);
        }

        public void UpdateSpeakingExamMeeting(SpeakingExamMeeting speakingExamMeeting)
        {
            Set.Update(speakingExamMeeting);
        }
    }
}
