using ExamContext.Listening.Aplication.Contracts.ListeningExamAggregate;
using ExamContext.Listening.Domain.ListeningExamAggregate.Services;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Aplication.ListeningExamAggregate
{
    public class DeleteListeningExamSectionCommandHandler : ICommandHandler<DeleteListeningExamSectionCommand>
    {
        private readonly IListeningExamSectionRepository listeningExamSectionRepository;
        public DeleteListeningExamSectionCommandHandler(IListeningExamSectionRepository listeningExamSectionRepository)
        {
            this.listeningExamSectionRepository = listeningExamSectionRepository;
        }
        public void Execute(DeleteListeningExamSectionCommand command)
        {
            var listeningExamSection = listeningExamSectionRepository.GetListeningExamSection(command.Id);
            listeningExamSection.IsDeleted = true;
            listeningExamSection.IsActive = false;

            listeningExamSectionRepository.UpdateListeningExamSection(listeningExamSection);
        }
    }
}
