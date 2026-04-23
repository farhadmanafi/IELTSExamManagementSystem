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
    public class ListeningUserAnswerCommandHandler : ICommandHandler<ListeningUserAnswerCommand>
    {
        private readonly IListeningUserAnswerRepository listeningUserAnswerRepository;
        public ListeningUserAnswerCommandHandler(IListeningUserAnswerRepository listeningUserAnswerRepository)
        {
            this.listeningUserAnswerRepository = listeningUserAnswerRepository;
        }
        public void Execute(ListeningUserAnswerCommand command)
        {
            foreach (var item in command.addListeningUserAnswerCommand)
            {
                var listeningUserAnswerDto = Mapper.Map<AddListeningUserAnswerCommand, ListeningUserAnswerDto>(item);
                var listeningUserAnswer = new ListeningUserAnswer(listeningUserAnswerDto);

                listeningUserAnswerRepository.AddListeningUserAnswer(listeningUserAnswer);
            }
        }
    }
}
