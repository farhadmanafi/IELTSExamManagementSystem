using ExamContext.Writing.Aplication.Contracts.WritingExamAggregate;
using ExamContext.Writing.Domain.WritingExamAggregate.Services;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Writing.Aplication.WritingExamAggregate
{
    public class UpdateWritingExamSectionCommandHandler : ICommandHandler<UpdateWritingExamSectionCommand>
    {
        private readonly IWritingExamSectionRepository writingExamSectionRepository;
        public UpdateWritingExamSectionCommandHandler(IWritingExamSectionRepository writingExamSectionRepository)
        {
            this.writingExamSectionRepository = writingExamSectionRepository;
        }
        public void Execute(UpdateWritingExamSectionCommand command)
        {
            var WritingExamSection = writingExamSectionRepository.GetWritingExamSection(command.Id);
            WritingExamSection.TitleSetter(command.Title);
            WritingExamSection.TimerMinutiesSetter(command.TimerMinuties);
            WritingExamSection.WritingTopicSetter(command.WritingTopic);

            writingExamSectionRepository.UpdateWritingExamSection(WritingExamSection);
        }
    }
}
