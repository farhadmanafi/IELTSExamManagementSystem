using ExamContext.Reading.Aplication.Contracts.ReadingUserAnswerAggregate;
using ExamContext.Reading.Domain.ReadingUserAnswerAggregate.Services;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Aplication.ReadingUserAnswerAggregate
{
    public class DeleteReadingUserAnswerCommandHandler :ICommandHandler<DeleteReadingUserAnswerCommand>
    {
        private readonly IReadingUserAnswerRepository readingUserAnswerRepository;
        public DeleteReadingUserAnswerCommandHandler(IReadingUserAnswerRepository readingUserAnswerRepository)
        {
            this.readingUserAnswerRepository = readingUserAnswerRepository;
        }
        public void Execute(DeleteReadingUserAnswerCommand command)
        {
            var readingUserAnswer = readingUserAnswerRepository.GetReadingUserAnswer(command.Id);
            readingUserAnswer.IsDeleted = true;
            readingUserAnswer.IsActive = false;

            readingUserAnswerRepository.UpdateReadingUserAnswer(readingUserAnswer);
        }
    }
}
