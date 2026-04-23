using ExamContext.Speaking.Aplication.Contracts.SpeakingExamMeetingAggregate;
using ExamContext.Speaking.Domain.Contracts.SpeakingExamMeetingAggregate;
using ExamContext.Speaking.Domain.SpeakingExamMeetingAggregate;
using ExamContext.Speaking.Domain.SpeakingExamMeetingAggregate.Services;
using Framework.Application;
using Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Speaking.Aplication.SpeakingExamMeetingAggregate
{
    public class AddSpeakingExamMeetingCommandHandler : ICommandHandler<AddSpeakingExamMeetingCommand>
    {
        private readonly ISpeakingExamMeetingRepository speakingExamMeetingRepository;
        public AddSpeakingExamMeetingCommandHandler(ISpeakingExamMeetingRepository speakingExamMeetingRepository)
        {
            this.speakingExamMeetingRepository = speakingExamMeetingRepository;
        }
        public void Execute(AddSpeakingExamMeetingCommand command)
        {
            var speakingExamMeetingDto = Mapper.Map<AddSpeakingExamMeetingCommand, SpeakingExamMeetingDto>(command);
            var speakingExamMeeting = new SpeakingExamMeeting(speakingExamMeetingDto);

            speakingExamMeetingRepository.AddSpeakingExamMeeting(speakingExamMeeting);
        }
    }
}
