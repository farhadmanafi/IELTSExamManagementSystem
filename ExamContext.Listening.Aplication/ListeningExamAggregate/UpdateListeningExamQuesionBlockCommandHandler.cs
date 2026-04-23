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
    public class UpdateListeningExamQuesionBlockCommandHandler : ICommandHandler<UpdateListeningExamQuestionBlockCommand>
    {
        private readonly IListeningExamQuestionBlockRepository listeningExamQuestionBlockRepository;
        public UpdateListeningExamQuesionBlockCommandHandler(IListeningExamQuestionBlockRepository listeningExamQuestionBlockRepository)
        {
            this.listeningExamQuestionBlockRepository = listeningExamQuestionBlockRepository;
        }
        public void Execute(UpdateListeningExamQuestionBlockCommand command)
        {
            var listeningExamQuestionBlock = listeningExamQuestionBlockRepository.GetListeningExamQuestionBlock(command.Id);
            //Changest
            listeningExamQuestionBlock.TitleSetter(command.Title);
            listeningExamQuestionBlock.OrderNo = command.OrderNo;
            listeningExamQuestionBlock.DescriptionSetter(command.Description);
            listeningExamQuestionBlockRepository.UpdateListeningExamQuestionBlock(listeningExamQuestionBlock);
        }
    }
}
