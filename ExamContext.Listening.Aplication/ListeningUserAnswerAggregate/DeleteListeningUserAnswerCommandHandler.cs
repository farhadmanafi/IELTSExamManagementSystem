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
    public class DeleteListeningUserAnswerCommandHandler : ICommandHandler<DeleteListeningUserAnswerCommand>
    {
        private readonly IListeningUserAnswerRepository listeningUserAnswerRepository;
        public DeleteListeningUserAnswerCommandHandler(IListeningUserAnswerRepository listeningUserAnswerRepository)
        {
            this.listeningUserAnswerRepository = listeningUserAnswerRepository;
        }
        public void Execute(DeleteListeningUserAnswerCommand command)
        {
            var listeningUserAnswer = listeningUserAnswerRepository.GetListeningUserAnswer(command.Id);
            listeningUserAnswer.IsDeleted = true;
            listeningUserAnswer.IsActive = false;

            listeningUserAnswerRepository.UpdateListeningUserAnswer(listeningUserAnswer);
        }
    }
}
