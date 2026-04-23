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
    public class AddListeningExamQuesionBlockCommandHandler : ICommandHandler<AddListeningExamQuestionBlockCommand>
    {
        private readonly IListeningExamQuestionBlockRepository listeningExamQuestionBlockRepository;
        public AddListeningExamQuesionBlockCommandHandler(IListeningExamQuestionBlockRepository listeningExamQuestionBlockRepository)
        {
            this.listeningExamQuestionBlockRepository = listeningExamQuestionBlockRepository;
        }
        public void Execute(AddListeningExamQuestionBlockCommand command)
        {
            var listeningExamQuestionBlockDto = Mapper.Map<AddListeningExamQuestionBlockCommand, ListeningExamQuesionBlockDto>(command);
            var listeningExamQuestionBlock = new ListeningExamQuestionBlock(listeningExamQuestionBlockDto);

            listeningExamQuestionBlockRepository.AddListeningExamQuestionBlock(listeningExamQuestionBlock);
        }
    }
}
