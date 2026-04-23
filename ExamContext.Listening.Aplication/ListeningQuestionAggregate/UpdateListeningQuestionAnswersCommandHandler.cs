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
    public class UpdateListeningQuestionAnswersCommandHandler : ICommandHandler<UpdateListeningQuestionAnswersCommand>
    {
        private readonly IListeningQuestionAnswersRepository listeningQuestionAnswersRepository;
        public UpdateListeningQuestionAnswersCommandHandler(IListeningQuestionAnswersRepository listeningQuestionAnswersRepository)
        {
            this.listeningQuestionAnswersRepository = listeningQuestionAnswersRepository;
        }
        public void Execute(UpdateListeningQuestionAnswersCommand command)
        {
            var listeningQuestionAnswers = listeningQuestionAnswersRepository.GetListeningQuestionAnswers(command.Id);
            //Changest
            listeningQuestionAnswers.TitleSetter(command.Title);
            listeningQuestionAnswers.DescriptionSetter(command.Description);
            listeningQuestionAnswers.OrderNo = command.OrderNo;
            listeningQuestionAnswers.IsCorrect = command.IsCorrect;
            listeningQuestionAnswers.IsActive = command.IsActive;

            listeningQuestionAnswersRepository.UpdateListeningQuestionAnswers(listeningQuestionAnswers);
        }
    }
}
