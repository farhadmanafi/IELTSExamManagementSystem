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
    public class SpeakingExamMeetingReserveCommandFacade : FacadeCommandBase, ISpeakingExamMeetingReserveCommandFacade
    {
        public SpeakingExamMeetingReserveCommandFacade(ICommandBus commandBus) : base(commandBus)
        {

        }

        public void AddSpeakingExamMeetingReserve(AddSpeakingExamMeetingReserveCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeleteSpeakingExamMeetingReserve(DeleteSpeakingExamMeetingReserveCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateSpeakingExamMeetingReserve(UpdateSpeakingExamMeetingReserveCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
