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
    public class SpeakingExamMeetingReserveRepository : RepositoryBase<SpeakingExamMeetingReserve>, ISpeakingExamMeetingReserveRepository
    {
        public SpeakingExamMeetingReserveRepository(IDbContext context) : base(context)
        {

        }

        public void AddSpeakingExamMeetingReserve(SpeakingExamMeetingReserve speakingExamMeetingReserve)
        {
            Set.Add(speakingExamMeetingReserve);
        }

        public void DeleteSpeakingExamMeetingReserve(SpeakingExamMeetingReserve speakingExamMeetingReserve)
        {
            Set.Update(speakingExamMeetingReserve);
        }

        public SpeakingExamMeetingReserve GetSpeakingExamMeetingReserve(Guid speakingExamMeetingReserveId)
        {
            return Set.SingleOrDefault(a => a.Id == speakingExamMeetingReserveId);
        }

        public void UpdateSpeakingExamMeetingReserve(SpeakingExamMeetingReserve speakingExamMeetingReserve)
        {
            Set.Update(speakingExamMeetingReserve);
        }
    }
}
