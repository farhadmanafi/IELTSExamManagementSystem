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
    public class AddReadingQuestionCommandHandler : ICommandHandler<AddReadingQuestionCommand>
    {
        private readonly IReadingQuestionRepository readingQuestionRepository;
        public AddReadingQuestionCommandHandler(IReadingQuestionRepository readingQuestionRepository)
        {
            this.readingQuestionRepository = readingQuestionRepository;
        }
        public void Execute(AddReadingQuestionCommand command)
        {
            var readingQuestionDto = Mapper.Map<AddReadingQuestionCommand, ReadingQuestionDto>(command);
            var readingQuestion = new ReadingQuestion(readingQuestionDto);

            readingQuestionRepository.AddReadingQuestion(readingQuestion);
        }
    }
}
