using ExamContext.Listening.Aplication.Contracts.ListeningQuestionAggregate;
using ExamContext.Listening.Domain.ListeningQuestionAggregate.Services;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Aplication.ListeningQuestionAggregate
{
    public class DeleteListeningQuestionAnswersCommandHandler : ICommandHandler<DeleteListeningQuestionAnswersCommand>
    {
        private readonly IListeningQuestionAnswersRepository listeningQuestionAnswersRepository;
        public DeleteListeningQuestionAnswersCommandHandler(IListeningQuestionAnswersRepository listeningQuestionAnswersRepository)
        {
            this.listeningQuestionAnswersRepository = listeningQuestionAnswersRepository;
        }
        public void Execute(DeleteListeningQuestionAnswersCommand command)
        {
            var listeningQuestionAnswers = listeningQuestionAnswersRepository.GetListeningQuestionAnswers(command.Id);
            listeningQuestionAnswers.IsDeleted = true;
            listeningQuestionAnswers.IsActive = false;

            listeningQuestionAnswersRepository.UpdateListeningQuestionAnswers(listeningQuestionAnswers);
        }
    }
}
