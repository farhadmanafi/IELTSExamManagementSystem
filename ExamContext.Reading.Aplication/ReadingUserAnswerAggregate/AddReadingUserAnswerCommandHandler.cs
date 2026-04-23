using ExamContext.Reading.Aplication.Contracts.ReadingUserAnswerAggregate;
using ExamContext.Reading.Domain.Contracts.ReadingUserAnswerAggregate;
using ExamContext.Reading.Domain.ReadingUserAnswerAggregate;
using ExamContext.Reading.Domain.ReadingUserAnswerAggregate.Services;
using Framework.Application;
using Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Aplication.ReadingUserAnswerAggregate
{
    public class AddReadingUserAnswerCommandHandler : ICommandHandler<AddReadingUserAnswerCommand>
    {
        private readonly IReadingUserAnswerRepository readingUserAnswerRepository;
        public AddReadingUserAnswerCommandHandler(IReadingUserAnswerRepository readingUserAnswerRepository)
        {
            this.readingUserAnswerRepository = readingUserAnswerRepository;
        }
        public void Execute(AddReadingUserAnswerCommand command)
        {
            var readingUserAnswerDto = Mapper.Map<AddReadingUserAnswerCommand, ReadingUserAnswerDto>(command);
            var readingUserAnswers = new ReadingUserAnswer(readingUserAnswerDto);

            readingUserAnswerRepository.AddReadingUserAnswer(readingUserAnswers);
        }
    }
}
