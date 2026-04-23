using ExamContext.Reading.Aplication.Contracts.ReadingExamAggregate;
using ExamContext.Reading.Domain.Contracts.ReadingExamAggregate;
using ExamContext.Reading.Domain.ReadingExamAggregate;
using ExamContext.Reading.Domain.ReadingExamAggregate.Services;
using Framework.Application;
using Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Aplication.ReadingExamAggregate
{
    public class AddReadingExamQuestionBlockCommandHandler : ICommandHandler<AddReadingExamQuestionBlockCommand>
    {
        private readonly IReadingExamQuestionBlockRepository readingExamQuestionBlockRepository;
        public AddReadingExamQuestionBlockCommandHandler(IReadingExamQuestionBlockRepository readingExamQuestionBlockRepository)
        {
            this.readingExamQuestionBlockRepository = readingExamQuestionBlockRepository;
        }
        public void Execute(AddReadingExamQuestionBlockCommand command)
        {
            var readingExamQuestionBlockDto = Mapper.Map<AddReadingExamQuestionBlockCommand, ReadingExamQuestionBlockDto>(command);
            var readingExamQuestionBlock = new ReadingExamQuestionBlock(readingExamQuestionBlockDto);

            readingExamQuestionBlockRepository.AddReadingExamQuestionBlock(readingExamQuestionBlock);
        }
    }
}
