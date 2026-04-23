using ExamContext.Speaking.Aplication.Contracts.SpeakingExamMeetingAggregate;
using ExamContext.Speaking.Facade.Contracts.SpeakingExamMeetingAggregate;
using Framework.Core.Application;
using Framework.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Speaking.Facade.SpeakingExamMeetingAggregate
{
    public class SpeakingExamMeetingCommandFacade : FacadeCommandBase, ISpeakingExamMeetingCommandFacade
    {
        public SpeakingExamMeetingCommandFacade(ICommandBus commandBus) : base(commandBus)
        {

        }

        public void AddSpeakingExamMeeting(AddSpeakingExamMeetingCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeleteSpeakingExamMeeting(DeleteSpeakingExamMeetingCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateSpeakingExamMeeting(UpdateSpeakingExamMeetingCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
