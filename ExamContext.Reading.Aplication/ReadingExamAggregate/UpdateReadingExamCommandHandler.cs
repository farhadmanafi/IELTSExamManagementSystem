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
    public class UpdateReadingExamCommandHandler : ICommandHandler<UpdateReadingExamCommand>
    {
        private readonly IReadingExamRepository readingExamRepository;
        public UpdateReadingExamCommandHandler(IReadingExamRepository readingExamRepository)
        {
            this.readingExamRepository = readingExamRepository;
        }
        public void Execute(UpdateReadingExamCommand command)
        {
            var readingExam = readingExamRepository.GetReadingExam(command.Id);
            readingExam.TitleSetter(command.Title);
            readingExam.DescriptionSetter(command.Description);
            readingExam.TimerMinutiesSetter(command.TimerMinuties);

            readingExamRepository.UpdateReadingExam(readingExam);
        }
    }
}
