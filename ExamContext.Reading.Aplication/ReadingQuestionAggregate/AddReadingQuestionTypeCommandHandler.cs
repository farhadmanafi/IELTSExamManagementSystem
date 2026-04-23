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
    public class AddReadingQuestionTypeCommandHandler : ICommandHandler<AddReadingQuestionTypeCommand>
    {
        private readonly IReadingQuestionTypeRepository readingQuestionTypeRepository;
        public AddReadingQuestionTypeCommandHandler(IReadingQuestionTypeRepository readingQuestionTypeRepository)
        {
            this.readingQuestionTypeRepository = readingQuestionTypeRepository;
        }
        public void Execute(AddReadingQuestionTypeCommand command)
        {
            var readingQuestionTypeDto = Mapper.Map<AddReadingQuestionTypeCommand, ReadingQuestionTypeDto>(command);
            var readingQuestionType = new ReadingQuestionType(readingQuestionTypeDto);

            readingQuestionTypeRepository.AddReadingQuestionType(readingQuestionType);
        }
    }
}
