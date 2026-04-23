using ExamContext.Speaking.Aplication.Contracts.SpeakingExamMeetingAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Speaking.Facade.Contracts.SpeakingExamMeetingAggregate
{
    public interface ISpeakingExamMeetingReserveCommandFacade
    {
        void AddSpeakingExamMeetingReserve(AddSpeakingExamMeetingReserveCommand command);
        void UpdateSpeakingExamMeetingReserve(UpdateSpeakingExamMeetingReserveCommand command);
        void DeleteSpeakingExamMeetingReserve(DeleteSpeakingExamMeetingReserveCommand command);
    }
}
