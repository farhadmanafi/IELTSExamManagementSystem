using ExamContext.Writing.Aplication.Contracts.WritingUserAnswerAggregate;
using ExamContext.Writing.Domain.Contracts.WritingUserContextAggregate;
using ExamContext.Writing.Domain.WritingUserAnswerAggregate;
using ExamContext.Writing.Domain.WritingUserAnswerAggregate.Services;
using Framework.Application;
using Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Writing.Aplication.WritingUserAnswerAggregate
{
    public class AddWritingUserAnswerCommandHandler : ICommandHandler<AddWritingUserAnswerCommand>
    {
        private readonly IWritingUserAnswerRepository writingUserAnswerRepository;
        public AddWritingUserAnswerCommandHandler(IWritingUserAnswerRepository writingUserAnswerRepository)
        {
            this.writingUserAnswerRepository = writingUserAnswerRepository;
        }
        public void Execute(AddWritingUserAnswerCommand command)
        {
            var writingUserAnswerDto = Mapper.Map<AddWritingUserAnswerCommand, WritingUserAnswerDto>(command);
            var writingUserAnswer = new WritingUserAnswer(writingUserAnswerDto);

            writingUserAnswerRepository.AddWritingUserAnswer(writingUserAnswer);
        }
    }
}
