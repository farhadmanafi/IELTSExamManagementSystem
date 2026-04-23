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
    public class UpdateReadingUserAnswerCommandHandler : ICommandHandler<UpdateReadingUserAnswerCommand>
    {
        private readonly IReadingUserAnswerRepository readingUserAnswerRepository;
        public UpdateReadingUserAnswerCommandHandler(IReadingUserAnswerRepository readingUserAnswerRepository)
        {
            this.readingUserAnswerRepository = readingUserAnswerRepository;
        }
        public void Execute(UpdateReadingUserAnswerCommand command)
        {
            var readingUserAnswer = readingUserAnswerRepository.GetReadingUserAnswer(command.Id);
            //Changest

            readingUserAnswerRepository.UpdateReadingUserAnswer(readingUserAnswer);
        }
    }
}
