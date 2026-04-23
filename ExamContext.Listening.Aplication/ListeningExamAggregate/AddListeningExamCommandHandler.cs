using ExamContext.Listening.Aplication.Contracts.ListeningExamAggregate;
using ExamContext.Listening.Domain.Contracts.ListeningExamAggregate;
using ExamContext.Listening.Domain.ListeningExamAggregate;
using ExamContext.Listening.Domain.ListeningExamAggregate.Services;
using Framework.Application;
using Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Aplication.ListeningExamAggregate
{
    public class AddListeningExamCommandHandler : ICommandHandler<AddListeningExamCommand>
    {
        private readonly IListeningExamRepository listeningExamRepository;
        public AddListeningExamCommandHandler(IListeningExamRepository listeningExamRepository)
        {
            this.listeningExamRepository = listeningExamRepository;
        }
        public void Execute(AddListeningExamCommand command)
        {
            var listeningExamDto = Mapper.Map<AddListeningExamCommand, ListeningExamDto>(command);
            var listeningExam = new ListeningExam(listeningExamDto);

            listeningExamRepository.AddListeningExam(listeningExam);
        }
    }
}
