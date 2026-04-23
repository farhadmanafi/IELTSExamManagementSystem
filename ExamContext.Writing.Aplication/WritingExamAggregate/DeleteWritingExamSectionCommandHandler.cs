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
    public class DeleteWritingExamSectionCommandHandler : ICommandHandler<DeleteWritingExamSectionCommand>
    {
        private readonly IWritingExamSectionRepository writingExamSectionRepository;
        public DeleteWritingExamSectionCommandHandler(IWritingExamSectionRepository writingExamSectionRepository)
        {
            this.writingExamSectionRepository = writingExamSectionRepository;
        }
        public void Execute(DeleteWritingExamSectionCommand command)
        {
            var writingExamSection = writingExamSectionRepository.GetWritingExamSection(command.Id);
            writingExamSection.IsDeleted = true;
            writingExamSection.IsActive = false;

            writingExamSectionRepository.UpdateWritingExamSection(writingExamSection);
        }
    }
}
