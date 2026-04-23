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
    public class DeleteReadingExamQuestionBlockCommandHandler : ICommandHandler<DeleteReadingExamQuestionBlockCommand>
    {
        private readonly IReadingExamQuestionBlockRepository readingExamQuestionBlockRepository;
        public DeleteReadingExamQuestionBlockCommandHandler(IReadingExamQuestionBlockRepository readingExamQuestionBlockRepository)
        {
            this.readingExamQuestionBlockRepository = readingExamQuestionBlockRepository;
        }
        public void Execute(DeleteReadingExamQuestionBlockCommand command)
        {
            var readingExamQuestionBlock = readingExamQuestionBlockRepository.GetReadingExamQuestionBlock(command.Id);
            readingExamQuestionBlock.IsDeleted = true;
            readingExamQuestionBlock.IsActive = false;

            readingExamQuestionBlockRepository.UpdateReadingExamQuestionBlock(readingExamQuestionBlock);
        }
    }
}
