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
    public class DeleteListeningExamQuesionBlockCommandHandler : ICommandHandler<DeleteListeningExamQuestionBlockCommand>
    {
        private readonly IListeningExamQuestionBlockRepository listeningExamQuestionBlockRepository;
        public DeleteListeningExamQuesionBlockCommandHandler(IListeningExamQuestionBlockRepository listeningExamQuestionBlockRepository)
        {
            this.listeningExamQuestionBlockRepository = listeningExamQuestionBlockRepository;
        }
        public void Execute(DeleteListeningExamQuestionBlockCommand command)
        {
            var listeningExamQuestionBlock = listeningExamQuestionBlockRepository.GetListeningExamQuestionBlock(command.Id);
            listeningExamQuestionBlock.IsDeleted = true;
            listeningExamQuestionBlock.IsActive = false;

            listeningExamQuestionBlockRepository.UpdateListeningExamQuestionBlock(listeningExamQuestionBlock);
        }
    }
}
