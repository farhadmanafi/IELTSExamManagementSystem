using ExamContext.Reading.Aplication.Contracts.ReadingQuestionAggregate;
using ExamContext.Reading.Domain.ReadingQuestionAggregate.Services;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Aplication.ReadingQuestionAggregate
{
    public class DeleteReadingQuestionTypeCommandHandler : ICommandHandler<DeleteReadingQuestionTypeCommand>
    {
        private readonly IReadingQuestionTypeRepository readingQuestionTypeRepository;
        public DeleteReadingQuestionTypeCommandHandler(IReadingQuestionTypeRepository readingQuestionTypeRepository)
        {
            this.readingQuestionTypeRepository = readingQuestionTypeRepository;
        }
        public void Execute(DeleteReadingQuestionTypeCommand command)
        {
            var readingQuestionType = readingQuestionTypeRepository.GetReadingQuestionType(command.Id);
            readingQuestionType.IsDeleted = true;
            readingQuestionType.IsActive = false;

            readingQuestionTypeRepository.UpdateReadingQuestionType(readingQuestionType);
        }
    }
}
