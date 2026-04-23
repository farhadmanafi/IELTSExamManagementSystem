using ExamContext.Speaking.Aplication.Contracts.SpeakingExamMeetingAggregate;
using ExamContext.Speaking.Domain.SpeakingExamMeetingAggregate.Services;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Speaking.Aplication.SpeakingExamMeetingAggregate
{
    public class DeleteSpeakingExamMeetingCommandHandler : ICommandHandler<DeleteSpeakingExamMeetingCommand>
    {
        private readonly ISpeakingExamMeetingRepository speakingExamMeetingRepository;
        public DeleteSpeakingExamMeetingCommandHandler(ISpeakingExamMeetingRepository speakingExamMeetingRepository)
        {
            this.speakingExamMeetingRepository = speakingExamMeetingRepository;
        }
        public void Execute(DeleteSpeakingExamMeetingCommand command)
        {
            var speakingExamMeeting = speakingExamMeetingRepository.GetSpeakingExamMeeting(command.Id);
            speakingExamMeeting.IsDeleted = true;
            speakingExamMeeting.IsActive = false;

            speakingExamMeetingRepository.UpdateSpeakingExamMeeting(speakingExamMeeting);
        }
    }
}
