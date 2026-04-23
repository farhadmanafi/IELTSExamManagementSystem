using ExamContext.Listening.Aplication.Contracts.ListeningExamAggregate;
using ExamContext.Listening.Domain.ListeningExamAggregate.Services;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Aplication.ListeningExamAggregate
{
    public class UpdateListeningExamCommandHandler : ICommandHandler<UpdateListeningExamCommand>
    {
        private readonly IListeningExamRepository listeningExamRepository;
        public UpdateListeningExamCommandHandler(IListeningExamRepository listeningExamRepository)
        {
            this.listeningExamRepository = listeningExamRepository;
        }
        public void Execute(UpdateListeningExamCommand command)
        {
            var listeningExam = listeningExamRepository.GetListeningExam(command.Id);
            //Changest
            listeningExam.TitleSetter(command.Title);
            listeningExam.DescriptionSetter(command.Description);
            listeningExam.VoiceSource = command.VoiceSource;
            listeningExam.TimerMinutiesSetter(command.TimerMinuties);

            listeningExamRepository.UpdateListeningExam(listeningExam);
        }
    }
}
