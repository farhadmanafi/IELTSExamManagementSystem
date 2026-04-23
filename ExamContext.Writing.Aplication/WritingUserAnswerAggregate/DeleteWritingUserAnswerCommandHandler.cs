using ExamContext.Writing.Aplication.Contracts.WritingUserAnswerAggregate;
using ExamContext.Writing.Domain.WritingUserAnswerAggregate.Services;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Writing.Aplication.WritingUserAnswerAggregate
{
    public class DeleteWritingUserAnswerCommandHandler : ICommandHandler<DeleteWritingUserAnswerCommand>
    {
        private readonly IWritingUserAnswerRepository writingUserAnswerRepository;
        public DeleteWritingUserAnswerCommandHandler(IWritingUserAnswerRepository writingUserAnswerRepository)
        {
            this.writingUserAnswerRepository = writingUserAnswerRepository;
        }
        public void Execute(DeleteWritingUserAnswerCommand command)
        {
            var writingUserAnswer = writingUserAnswerRepository.GetWritingUserAnswer(command.Id);
            writingUserAnswer.IsDeleted = true;
            writingUserAnswer.IsActive = false;

            writingUserAnswerRepository.UpdateWritingUserAnswer(writingUserAnswer);
        }
    }
}
