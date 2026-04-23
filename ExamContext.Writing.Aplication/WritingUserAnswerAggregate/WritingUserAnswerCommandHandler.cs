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
    public class WritingUserAnswerCommandHandler : ICommandHandler<WritingUserAnswerCommand>
    {
        private readonly IWritingUserAnswerRepository writingUserAnswerRepository;
        public WritingUserAnswerCommandHandler(IWritingUserAnswerRepository writingUserAnswerRepository)
        {
            this.writingUserAnswerRepository = writingUserAnswerRepository;
        }
        public void Execute(WritingUserAnswerCommand command)
        {

            foreach (var item in command.addWritingUserAnswerCommand)
            {
                var writingUserAnswerDto = Mapper.Map<AddWritingUserAnswerCommand, WritingUserAnswerDto>(item);
                var writingUserAnswer = new WritingUserAnswer(writingUserAnswerDto);

                writingUserAnswerRepository.AddWritingUserAnswer(writingUserAnswer);
            }
        }
    }
}
