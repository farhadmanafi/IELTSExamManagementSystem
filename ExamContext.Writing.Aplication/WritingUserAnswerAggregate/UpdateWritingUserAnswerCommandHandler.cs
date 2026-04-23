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
    public class UpdateWritingUserAnswerCommandHandler : ICommandHandler<UpdateWritingUserAnswerCommand>
    {
        private readonly IWritingUserAnswerRepository writingUserAnswerRepository;
        public UpdateWritingUserAnswerCommandHandler(IWritingUserAnswerRepository writingUserAnswerRepository)
        {
            this.writingUserAnswerRepository = writingUserAnswerRepository;
        }
        public void Execute(UpdateWritingUserAnswerCommand command)
        {
            var writingUserAnswer = writingUserAnswerRepository.GetWritingUserAnswer(command.Id);
            //Changest

            writingUserAnswerRepository.UpdateWritingUserAnswer(writingUserAnswer);
        }
    }
}
