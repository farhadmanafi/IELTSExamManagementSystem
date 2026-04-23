using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Speaking.Domain.SpeakingExamMeetingAggregate.Services
{
    public interface ISpeakingExamMeetingReserveRepository
    {
        void AddSpeakingExamMeetingReserve(SpeakingExamMeetingReserve speakingExamMeetingReserve);
        SpeakingExamMeetingReserve GetSpeakingExamMeetingReserve(Guid speakingExamMeetingReserveId);
        void UpdateSpeakingExamMeetingReserve(SpeakingExamMeetingReserve speakingExamMeetingReserve);
        void DeleteSpeakingExamMeetingReserve(SpeakingExamMeetingReserve speakingExamMeetingReserve);
    }
}
