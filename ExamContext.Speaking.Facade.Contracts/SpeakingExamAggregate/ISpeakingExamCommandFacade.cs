using ExamContext.Speaking.Aplication.Contracts.SpeakingExamAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Speaking.Facade.Contracts.SpeakingExamAggregate
{
    public interface ISpeakingExamCommandFacade
    {
        void AddSpeakingExam(AddSpeakingExamCommand command);
        void UpdateSpeakingExam(UpdateSpeakingExamCommand command);
        void DeleteSpeakingExam(DeleteSpeakingExamCommand command);
    }
}
