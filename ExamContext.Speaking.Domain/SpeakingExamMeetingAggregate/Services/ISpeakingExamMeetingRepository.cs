using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Speaking.Domain.SpeakingExamMeetingAggregate.Services
{
    public interface ISpeakingExamMeetingRepository
    {
        void AddSpeakingExamMeeting(SpeakingExamMeeting speakingExamMeeting);
        SpeakingExamMeeting GetSpeakingExamMeeting(Guid speakingExamMeetingId);
        void UpdateSpeakingExamMeeting(SpeakingExamMeeting speakingExamMeeting);
        void DeleteSpeakingExamMeeting(SpeakingExamMeeting speakingExamMeeting);
    }
}
