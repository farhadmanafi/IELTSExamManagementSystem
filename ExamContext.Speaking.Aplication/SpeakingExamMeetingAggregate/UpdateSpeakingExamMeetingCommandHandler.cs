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
    public class UpdateSpeakingExamMeetingCommandHandler : ICommandHandler<UpdateSpeakingExamMeetingCommand>
    {
        private readonly ISpeakingExamMeetingRepository speakingExamMeetingRepository;
        public UpdateSpeakingExamMeetingCommandHandler(ISpeakingExamMeetingRepository speakingExamMeetingRepository)
        {
            this.speakingExamMeetingRepository = speakingExamMeetingRepository;
        }
        public void Execute(UpdateSpeakingExamMeetingCommand command)
        {
            var SpeakingExamMeeting = speakingExamMeetingRepository.GetSpeakingExamMeeting(command.Id);
            //Changest
            SpeakingExamMeeting.TitleSetter(command.Title);
            SpeakingExamMeeting.MeetingDate = command.MeetingDate;
            SpeakingExamMeeting.MeetingStartTime = command.MeetingStartTime;
            SpeakingExamMeeting.MeetingEndTime = command.MeetingEndTime;
            SpeakingExamMeeting.IsActive = command.IsActive;

            speakingExamMeetingRepository.UpdateSpeakingExamMeeting(SpeakingExamMeeting);
        }
    }
}
