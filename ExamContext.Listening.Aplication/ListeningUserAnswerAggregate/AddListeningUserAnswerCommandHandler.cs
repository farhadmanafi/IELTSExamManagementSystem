using ExamContext.Listening.Aplication.Contracts.ListeningUserAnswerAggregate;
using ExamContext.Listening.Domain.Contracts.ListeningUserAnswerAggregate;
using ExamContext.Listening.Domain.ListeningUserAnswerAggregate;
using ExamContext.Listening.Domain.ListeningUserAnswerAggregate.Services;
using Framework.Application;
using Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Aplication.ListeningUserAnswerAggregate
{
    public class AddListeningUserAnswerCommandHandler : ICommandHandler<AddListeningUserAnswerCommand>
    {
        private readonly IListeningUserAnswerRepository listeningUserAnswerRepository;
        public AddListeningUserAnswerCommandHandler(IListeningUserAnswerRepository listeningUserAnswerRepository)
        {
            this.listeningUserAnswerRepository = listeningUserAnswerRepository;
        }
        public void Execute(AddListeningUserAnswerCommand command)
        {
            var listeningUserAnswerDto = Mapper.Map<AddListeningUserAnswerCommand, ListeningUserAnswerDto>(command);
            var listeningUserAnswers = new ListeningUserAnswer(listeningUserAnswerDto);

            listeningUserAnswerRepository.AddListeningUserAnswer(listeningUserAnswers);
        }
    }
}
