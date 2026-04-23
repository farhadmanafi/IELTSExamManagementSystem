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
    public class DeleteReadingQuestionCommandHandler : ICommandHandler<DeleteReadingQuestionCommand>
    {
        private readonly IReadingQuestionRepository readingQuestionRepository;
        public DeleteReadingQuestionCommandHandler(IReadingQuestionRepository readingQuestionRepository)
        {
            this.readingQuestionRepository = readingQuestionRepository;
        }
        public void Execute(DeleteReadingQuestionCommand command)
        {
            var readingQuestion = readingQuestionRepository.GetReadingQuestion(command.Id);
            readingQuestion.IsDeleted = true;
            readingQuestion.IsActive = false;

            readingQuestionRepository.UpdateReadingQuestion(readingQuestion);
        }
    }
}
