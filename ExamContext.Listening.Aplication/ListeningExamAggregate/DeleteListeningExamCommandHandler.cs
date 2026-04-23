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
    public class DeleteListeningExamCommandHandler : ICommandHandler<DeleteListeningExamCommand>
    {
        private readonly IListeningExamRepository listeningExamRepository;
        public DeleteListeningExamCommandHandler(IListeningExamRepository listeningExamRepository)
        {
            this.listeningExamRepository = listeningExamRepository;
        }
        public void Execute(DeleteListeningExamCommand command)
        {
            var ListeningExam = listeningExamRepository.GetListeningExam(command.Id);
            ListeningExam.IsDeleted = true;
            ListeningExam.IsActive = false;

            listeningExamRepository.UpdateListeningExam(ListeningExam);
        }
    }
}
