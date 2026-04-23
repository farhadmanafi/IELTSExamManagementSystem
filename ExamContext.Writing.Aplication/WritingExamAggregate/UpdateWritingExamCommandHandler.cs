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
    public class UpdateWritingExamCommandHandler : ICommandHandler<UpdateWritingExamCommand>
    {
        private readonly IWritingExamRepository writingExamRepository;
        public UpdateWritingExamCommandHandler(IWritingExamRepository writingExamRepository)
        {
            this.writingExamRepository = writingExamRepository;
        }
        public void Execute(UpdateWritingExamCommand command)
        {
            var writingExam = writingExamRepository.GetWritingExam(command.Id);
            writingExam.TitleSetter(command.Title);
            writingExam.DescriptionSetter(command.Description);
            writingExam.TimerMinutiesSetter(command.TimerMinuties);

            writingExamRepository.UpdateWritingExam(writingExam);
        }
    }
}
