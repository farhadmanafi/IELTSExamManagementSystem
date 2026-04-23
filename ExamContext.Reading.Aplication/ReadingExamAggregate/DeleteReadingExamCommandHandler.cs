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
    public class DeleteReadingExamCommandHandler : ICommandHandler<DeleteReadingExamCommand>
    {
        private readonly IReadingExamRepository readingExamRepository;
        public DeleteReadingExamCommandHandler(IReadingExamRepository readingExamRepository)
        {
            this.readingExamRepository = readingExamRepository;
        }
        public void Execute(DeleteReadingExamCommand command)
        {
            var readingExam = readingExamRepository.GetReadingExam(command.Id);
            readingExam.IsDeleted = true;
            readingExam.IsActive = false;

            readingExamRepository.UpdateReadingExam(readingExam);
        }
    }
}
