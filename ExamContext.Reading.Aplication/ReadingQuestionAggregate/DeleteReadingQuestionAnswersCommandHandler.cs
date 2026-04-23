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
    public class DeleteReadingQuestionAnswersCommandHandler : ICommandHandler<DeleteReadingQuestionAnswersCommand>
    {
        private readonly IReadingQuestionAnswersRepository readingQuestionAnswersRepository;
        public DeleteReadingQuestionAnswersCommandHandler(IReadingQuestionAnswersRepository readingQuestionAnswersRepository)
        {
            this.readingQuestionAnswersRepository = readingQuestionAnswersRepository;
        }
        public void Execute(DeleteReadingQuestionAnswersCommand command)
        {
            var readingQuestionAnswers = readingQuestionAnswersRepository.GetReadingQuestionAnswers(command.Id);
            readingQuestionAnswers.IsDeleted = true;
            readingQuestionAnswers.IsActive = false;

            readingQuestionAnswersRepository.UpdateReadingQuestionAnswers(readingQuestionAnswers);
        }
    }
}
