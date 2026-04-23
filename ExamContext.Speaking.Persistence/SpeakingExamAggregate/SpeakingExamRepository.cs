using ExamContext.Speaking.Domain.SpeakingExamAggregate;
using ExamContext.Speaking.Domain.SpeakingExamAggregate.Services;
using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Speaking.Persistence.SpeakingExamAggregate
{
    public class SpeakingExamRepository : RepositoryBase<SpeakingExam>, ISpeakingExamRepository
    {
        public SpeakingExamRepository(IDbContext context) : base(context)
        {

        }

        public void AddSpeakingExam(SpeakingExam speakingExam)
        {
            Set.Add(speakingExam);
        }

        public void DeleteSpeakingExam(SpeakingExam speakingExam)
        {
            Set.Update(speakingExam);
        }

        public SpeakingExam GetSpeakingExam(Guid speakingExamId)
        {
            return Set.SingleOrDefault(a => a.Id == speakingExamId);
        }

        public void UpdateSpeakingExam(SpeakingExam speakingExam)
        {
            Set.Update(speakingExam);
        }
    }
}
