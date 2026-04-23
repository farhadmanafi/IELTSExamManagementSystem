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
    public class UpdateListeningExamSectionCommandHandler : ICommandHandler<UpdateListeningExamSectionCommand>
    {
        private readonly IListeningExamSectionRepository listeningExamSectionRepository;
        public UpdateListeningExamSectionCommandHandler(IListeningExamSectionRepository listeningExamSectionRepository)
        {
            this.listeningExamSectionRepository = listeningExamSectionRepository;
        }
        public void Execute(UpdateListeningExamSectionCommand command)
        {
            var listeningExamSection = listeningExamSectionRepository.GetListeningExamSection(command.Id);
            //Changest
            listeningExamSection.TitleSetter(command.Title);
            listeningExamSection.OrderNo = command.OrderNo;

            listeningExamSectionRepository.UpdateListeningExamSection(listeningExamSection);
        }
    }
}
