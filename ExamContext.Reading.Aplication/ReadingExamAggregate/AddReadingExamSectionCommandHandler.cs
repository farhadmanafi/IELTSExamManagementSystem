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
    public class AddReadingExamSectionCommandHandler : ICommandHandler<AddReadingExamSectionCommand>
    {
        private readonly IReadingExamSectionRepository readingExamSectionRepository;
        public AddReadingExamSectionCommandHandler(IReadingExamSectionRepository readingExamSectionRepository)
        {
            this.readingExamSectionRepository = readingExamSectionRepository;
        }
        public void Execute(AddReadingExamSectionCommand command)
        {
            var readingExamSectionDto = Mapper.Map<AddReadingExamSectionCommand, ReadingExamSectionDto>(command);
            var readingExamSection = new ReadingExamSection(readingExamSectionDto);

            readingExamSectionRepository.AddReadingExamSection(readingExamSection);
        }
    }
}
