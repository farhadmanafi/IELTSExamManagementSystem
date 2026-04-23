using ExamContext.Speaking.Aplication.Contracts.SpeakingExamAggregate;
using ExamContext.Speaking.Domain.SpeakingExamAggregate.Services;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Speaking.Aplication.SpeakingExamAggregate
{
    public class DeleteSpeakingExamCommandHandler : ICommandHandler<DeleteSpeakingExamCommand>
    {
        private readonly ISpeakingExamRepository speakingExamRepository;
        public DeleteSpeakingExamCommandHandler(ISpeakingExamRepository speakingExamRepository)
        {
            this.speakingExamRepository = speakingExamRepository;
        }
        public void Execute(DeleteSpeakingExamCommand command)
        {
            var speakingExam = speakingExamRepository.GetSpeakingExam(command.Id);
            speakingExam.IsDeleted = true;
            speakingExam.IsActive = false;

            speakingExamRepository.UpdateSpeakingExam(speakingExam);
        }
    }
}
