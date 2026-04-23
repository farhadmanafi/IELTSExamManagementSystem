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
    public class ReadingUserAnswerCommandHandler : ICommandHandler<ReadingUserAnswerCommand>
    {
        private readonly IReadingUserAnswerRepository readingUserAnswerRepository;
        public ReadingUserAnswerCommandHandler(IReadingUserAnswerRepository readingUserAnswerRepository)
        {
            this.readingUserAnswerRepository = readingUserAnswerRepository;
        }
        public void Execute(ReadingUserAnswerCommand command)
        {
            foreach (var item in command.addReadingUserAnswerCommand)
            {
                var readingUserAnswerDto = Mapper.Map<AddReadingUserAnswerCommand, ReadingUserAnswerDto>(item);
                var readingUserAnswer = new ReadingUserAnswer(readingUserAnswerDto);

                readingUserAnswerRepository.AddReadingUserAnswer(readingUserAnswer);
            }
        }
    }
}
