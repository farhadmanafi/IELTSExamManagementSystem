using ExamContext.Reading.Aplication.Contracts.ReadingQuestionAggregate;
using ExamContext.Reading.Domain.Contracts.ReadingQuestionAggregate;
using ExamContext.Reading.Domain.ReadingQuestionAggregate;
using ExamContext.Reading.Domain.ReadingQuestionAggregate.Services;
using Framework.Application;
using Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Aplication.ReadingQuestionAggregate
{
    public class AddReadingQuestionAnswersCommandHandler : ICommandHandler<AddReadingQuestionAnswersCommand>
    {
        private readonly IReadingQuestionAnswersRepository readingQuestionAnswersRepository;
        public AddReadingQuestionAnswersCommandHandler(IReadingQuestionAnswersRepository readingQuestionAnswersRepository)
        {
            this.readingQuestionAnswersRepository = readingQuestionAnswersRepository;
        }
        public void Execute(AddReadingQuestionAnswersCommand command)
        {
            var readingQuestionAnswersDto = Mapper.Map<AddReadingQuestionAnswersCommand, ReadingQuestionAnswersDto>(command);
            var readingQuestionAnswers = new ReadingQuestionAnswers(readingQuestionAnswersDto);

            readingQuestionAnswersRepository.AddReadingQuestionAnswers(readingQuestionAnswers);
        }
    }
}
