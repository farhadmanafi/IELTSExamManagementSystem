using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Speaking.Domain.SpeakingExamAggregate.Services
{
    public interface ISpeakingExamRepository
    {
        void AddSpeakingExam(SpeakingExam speakingExam);
        SpeakingExam GetSpeakingExam(Guid speakingExamId);
        void UpdateSpeakingExam(SpeakingExam speakingExam);
        void DeleteSpeakingExam(SpeakingExam speakingExam);
    }
}
