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
    public class AddListeningQuestionCommandHandler : ICommandHandler<AddListeningQuestionCommand>
    {
        private readonly IListeningQuestionRepository listeningQuestionRepository;
        public AddListeningQuestionCommandHandler(IListeningQuestionRepository listeningQuestionRepository)
        {
            this.listeningQuestionRepository = listeningQuestionRepository;
        }
        public void Execute(AddListeningQuestionCommand command)
        {
            var listeningQuestionDto = Mapper.Map<AddListeningQuestionCommand, ListeningQuestionDto>(command);
            var listeningQuestion = new ListeningQuestion(listeningQuestionDto);

            listeningQuestionRepository.AddListeningQuestion(listeningQuestion);
        }
    }
}
