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
    public class UpdateReadingQuestionAnswersCommandHandler : ICommandHandler<UpdateReadingQuestionAnswersCommand>
    {
        private readonly IReadingQuestionAnswersRepository readingQuestionAnswersRepository;
        public UpdateReadingQuestionAnswersCommandHandler(IReadingQuestionAnswersRepository readingQuestionAnswersRepository)
        {
            this.readingQuestionAnswersRepository = readingQuestionAnswersRepository;
        }
        public void Execute(UpdateReadingQuestionAnswersCommand command)
        {
            var readingQuestionAnswers = readingQuestionAnswersRepository.GetReadingQuestionAnswers(command.Id);
            readingQuestionAnswers.TitleSetter(command.Title);
            readingQuestionAnswers.DescriptionSetter(command.Description);
            readingQuestionAnswers.OrderNo = command.OrderNo;
            readingQuestionAnswers.IsActive = command.IsActive;
            readingQuestionAnswers.IsCorrect = command.IsCorrect;

            readingQuestionAnswersRepository.UpdateReadingQuestionAnswers(readingQuestionAnswers);
        }
    }
}
