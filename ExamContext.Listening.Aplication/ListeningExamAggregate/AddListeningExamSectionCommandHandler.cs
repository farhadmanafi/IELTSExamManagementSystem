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
    public class AddListeningExamSectionCommandHandler : ICommandHandler<AddListeningExamSectionCommand>
    {
        private readonly IListeningExamSectionRepository listeningExamSectionRepository;
        public AddListeningExamSectionCommandHandler(IListeningExamSectionRepository listeningExamSectionRepository)
        {
            this.listeningExamSectionRepository = listeningExamSectionRepository;
        }
        public void Execute(AddListeningExamSectionCommand command)
        {
            var listeningExamSectionDto = Mapper.Map<AddListeningExamSectionCommand, ListeningExamSectionDto>(command);
            var listeningExamSection = new ListeningExamSection(listeningExamSectionDto);

            listeningExamSectionRepository.AddListeningExamSection(listeningExamSection);
        }
    }
}
