using ExamContext.Listening.Aplication.Contracts.ListeningUserAnswerAggregate;
using ExamContext.Listening.Domain.ListeningUserAnswerAggregate.Services;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Aplication.ListeningUserAnswerAggregate
{
    public class UpdateListeningUserAnswerCommandHandler : ICommandHandler<UpdateListeningUserAnswerCommand>
    {
        private readonly IListeningUserAnswerRepository listeningUserAnswerRepository;
        public UpdateListeningUserAnswerCommandHandler(IListeningUserAnswerRepository listeningUserAnswerRepository)
        {
            this.listeningUserAnswerRepository = listeningUserAnswerRepository;
        }
        public void Execute(UpdateListeningUserAnswerCommand command)
        {
            var listeningUserAnswer = listeningUserAnswerRepository.GetListeningUserAnswer(command.Id);
            //Changest

            listeningUserAnswerRepository.UpdateListeningUserAnswer(listeningUserAnswer);
        }
    }
}
