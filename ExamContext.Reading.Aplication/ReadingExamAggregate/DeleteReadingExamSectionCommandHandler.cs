using ExamContext.Reading.Aplication.Contracts.ReadingExamAggregate;
using ExamContext.Reading.Domain.ReadingExamAggregate.Services;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Aplication.ReadingExamAggregate
{
    public class DeleteReadingExamSectionCommandHandler : ICommandHandler<DeleteReadingExamSectionCommand>
    {
        private readonly IReadingExamSectionRepository readingExamSectionRepository;
        public DeleteReadingExamSectionCommandHandler(IReadingExamSectionRepository readingExamSectionRepository)
        {
            this.readingExamSectionRepository = readingExamSectionRepository;
        }
        public void Execute(DeleteReadingExamSectionCommand command)
        {
            var readingExamSection = readingExamSectionRepository.GetReadingExamSection(command.Id);
            readingExamSection.IsDeleted = true;
            readingExamSection.IsActive = false;

            readingExamSectionRepository.UpdateReadingExamSection(readingExamSection);
        }
    }
}
