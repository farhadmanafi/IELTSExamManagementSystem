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
    public class DeleteWritingExamCommandHandler : ICommandHandler<DeleteWritingExamCommand>
    {
        private readonly IWritingExamRepository writingExamRepository;
        public DeleteWritingExamCommandHandler(IWritingExamRepository writingExamRepository)
        {
            this.writingExamRepository = writingExamRepository;
        }
        public void Execute(DeleteWritingExamCommand command)
        {
            var writingExam = writingExamRepository.GetWritingExam(command.Id);
            writingExam.IsDeleted = true;
            writingExam.IsActive = false;

            writingExamRepository.UpdateWritingExam(writingExam);
        }
    }
}
