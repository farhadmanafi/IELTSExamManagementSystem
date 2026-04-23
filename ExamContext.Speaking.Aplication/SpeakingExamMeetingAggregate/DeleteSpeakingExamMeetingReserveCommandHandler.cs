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
    public class DeleteSpeakingExamMeetingReserveCommandHandler : ICommandHandler<DeleteSpeakingExamMeetingReserveCommand>
    {
        private readonly ISpeakingExamMeetingReserveRepository speakingExamMeetingReserveRepository;
        public DeleteSpeakingExamMeetingReserveCommandHandler(ISpeakingExamMeetingReserveRepository speakingExamMeetingReserveRepository)
        {
            this.speakingExamMeetingReserveRepository = speakingExamMeetingReserveRepository;
        }
        public void Execute(DeleteSpeakingExamMeetingReserveCommand command)
        {
            var speakingExamMeetingReserve = speakingExamMeetingReserveRepository.GetSpeakingExamMeetingReserve(command.Id);
            speakingExamMeetingReserve.IsDeleted = true;
            speakingExamMeetingReserve.IsActive = false;

            speakingExamMeetingReserveRepository.UpdateSpeakingExamMeetingReserve(speakingExamMeetingReserve);
        }
    }
}
