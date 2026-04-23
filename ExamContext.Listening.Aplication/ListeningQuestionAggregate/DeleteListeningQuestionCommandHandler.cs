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
    public class DeleteListeningQuestionCommandHandler : ICommandHandler<DeleteListeningQuestionCommand>
    {
        private readonly IListeningQuestionRepository listeningQuestionRepository;
        public DeleteListeningQuestionCommandHandler(IListeningQuestionRepository listeningQuestionRepository)
        {
            this.listeningQuestionRepository = listeningQuestionRepository;
        }
        public void Execute(DeleteListeningQuestionCommand command)
        {
            var listeningQuestion = listeningQuestionRepository.GetListeningQuestion(command.Id);
            listeningQuestion.IsDeleted = true;
            listeningQuestion.IsActive = false;

            listeningQuestionRepository.UpdateListeningQuestion(listeningQuestion);
        }
    }
}
