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
    public class UpdateSpeakingExamCommandHandler : ICommandHandler<UpdateSpeakingExamCommand>
    {
        private readonly ISpeakingExamRepository speakingExamRepository;
        public UpdateSpeakingExamCommandHandler(ISpeakingExamRepository speakingExamRepository)
        {
            this.speakingExamRepository = speakingExamRepository;
        }
        public void Execute(UpdateSpeakingExamCommand command)
        {
            var speakingExam = speakingExamRepository.GetSpeakingExam(command.Id);
            //Changest
            speakingExam.TitleSetter(command.Title);
            speakingExam.DescriptionSetter(command.Description);
            speakingExam.IsActive = command.IsActive;

            speakingExamRepository.UpdateSpeakingExam(speakingExam);
        }
    }
}
