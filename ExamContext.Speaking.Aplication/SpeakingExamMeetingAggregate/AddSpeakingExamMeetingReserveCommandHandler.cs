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
    public class AddSpeakingExamMeetingReserveCommandHandler : ICommandHandler<AddSpeakingExamMeetingReserveCommand>
    {
        private readonly ISpeakingExamMeetingReserveRepository speakingExamMeetingReserveRepository;
        public AddSpeakingExamMeetingReserveCommandHandler(ISpeakingExamMeetingReserveRepository speakingExamMeetingReserveRepository)
        {
            this.speakingExamMeetingReserveRepository = speakingExamMeetingReserveRepository;
        }
        public void Execute(AddSpeakingExamMeetingReserveCommand command)
        {
            var speakingExamMeetingReserveDto = Mapper.Map<AddSpeakingExamMeetingReserveCommand, SpeakingExamMeetingReserveDto>(command);
            var speakingExamMeetingReserve = new SpeakingExamMeetingReserve(speakingExamMeetingReserveDto);

            speakingExamMeetingReserveRepository.AddSpeakingExamMeetingReserve(speakingExamMeetingReserve);
        }
    }
}
