using ExamContext.Listening.Aplication.Contracts.ListeningQuestionAggregate;
using ExamContext.Listening.Domain.Contracts.ListeningQuestionAggregate;
using ExamContext.Listening.Domain.ListeningQuestionAggregate;
using ExamContext.Listening.Domain.ListeningQuestionAggregate.Services;
using Framework.Application;
using Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Aplication.ListeningQuestionAggregate
{
    public class AddListeningQuestionAnswersCommandHandler : ICommandHandler<AddListeningQuestionAnswersCommand>
    {
        private readonly IListeningQuestionAnswersRepository listeningQuestionAnswersRepository;
        public AddListeningQuestionAnswersCommandHandler(IListeningQuestionAnswersRepository listeningQuestionAnswersRepository)
        {
            this.listeningQuestionAnswersRepository = listeningQuestionAnswersRepository;
        }
        public void Execute(AddListeningQuestionAnswersCommand command)
        {
            var listeningQuestionAnswersDto = Mapper.Map<AddListeningQuestionAnswersCommand, ListeningQuestionAnswersDto>(command);
            var listeningQuestionAnswers = new ListeningQuestionAnswers(listeningQuestionAnswersDto);

            listeningQuestionAnswersRepository.AddListeningQuestionAnswers(listeningQuestionAnswers);
        }
    }
}
