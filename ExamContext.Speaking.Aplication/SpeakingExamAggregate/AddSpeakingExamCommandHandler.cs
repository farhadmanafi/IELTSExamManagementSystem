using ExamContext.Speaking.Aplication.Contracts.SpeakingExamAggregate;
using ExamContext.Speaking.Domain.Contracts.SpeakingExamAggregate;
using ExamContext.Speaking.Domain.SpeakingExamAggregate;
using ExamContext.Speaking.Domain.SpeakingExamAggregate.Services;
using Framework.Application;
using Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Speaking.Aplication.SpeakingExamAggregate
{
    public class AddSpeakingExamCommandHandler : ICommandHandler<AddSpeakingExamCommand>
    {
        private readonly ISpeakingExamRepository speakingExamRepository;
        public AddSpeakingExamCommandHandler(ISpeakingExamRepository speakingExamRepository)
        {
            this.speakingExamRepository = speakingExamRepository;
        }
        public void Execute(AddSpeakingExamCommand command)
        {
            var speakingExamDto = Mapper.Map<AddSpeakingExamCommand, SpeakingExamDto>(command);
            var speakingExam = new SpeakingExam(speakingExamDto);

            speakingExamRepository.AddSpeakingExam(speakingExam);
        }
    }
}
