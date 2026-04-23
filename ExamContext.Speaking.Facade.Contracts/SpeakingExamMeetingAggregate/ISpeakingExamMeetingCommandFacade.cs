using ExamContext.Speaking.Aplication.Contracts.SpeakingExamMeetingAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Speaking.Facade.Contracts.SpeakingExamMeetingAggregate
{
    public interface ISpeakingExamMeetingCommandFacade
    {
        void AddSpeakingExamMeeting(AddSpeakingExamMeetingCommand command);
        void UpdateSpeakingExamMeeting(UpdateSpeakingExamMeetingCommand command);
        void DeleteSpeakingExamMeeting(DeleteSpeakingExamMeetingCommand command);
    }
}
