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
    public class UpdateSpeakingExamMeetingReserveCommandHandler : ICommandHandler<UpdateSpeakingExamMeetingReserveCommand>
    {
        private readonly ISpeakingExamMeetingReserveRepository speakingExamMeetingReserveRepository;
        public UpdateSpeakingExamMeetingReserveCommandHandler(ISpeakingExamMeetingReserveRepository speakingExamMeetingReserveRepository)
        {
            this.speakingExamMeetingReserveRepository = speakingExamMeetingReserveRepository;
        }
        public void Execute(UpdateSpeakingExamMeetingReserveCommand command)
        {
            var speakingExamMeetingReserve = speakingExamMeetingReserveRepository.GetSpeakingExamMeetingReserve(command.Id);
            //Changest

            speakingExamMeetingReserveRepository.UpdateSpeakingExamMeetingReserve(speakingExamMeetingReserve);
        }
    }
}
