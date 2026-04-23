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
    public class UpdateReadingExamSectionCommandHandler : ICommandHandler<UpdateReadingExamSectionCommand>
    {
        private readonly IReadingExamSectionRepository readingExamSectionRepository;
        public UpdateReadingExamSectionCommandHandler(IReadingExamSectionRepository readingExamSectionRepository)
        {
            this.readingExamSectionRepository = readingExamSectionRepository;
        }
        public void Execute(UpdateReadingExamSectionCommand command)
        {
            var readingExamSection = readingExamSectionRepository.GetReadingExamSection(command.Id);
            readingExamSection.TitleSetter(command.Title);
            readingExamSection.DescriptionSetter(command.Description);
            readingExamSection.ReadingText = command.ReadingText;
            readingExamSection.OrderNo = command.OrderNo;

            readingExamSectionRepository.UpdateReadingExamSection(readingExamSection);
        }
    }
}
