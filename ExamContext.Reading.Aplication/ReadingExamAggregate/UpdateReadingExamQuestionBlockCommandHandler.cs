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
    public class UpdateReadingExamQuestionBlockCommandHandler : ICommandHandler<UpdateReadingExamQuestionBlockCommand>
    {
        private readonly IReadingExamQuestionBlockRepository readingExamQuestionBlockRepository;
        public UpdateReadingExamQuestionBlockCommandHandler(IReadingExamQuestionBlockRepository readingExamQuestionBlockRepository)
        {
            this.readingExamQuestionBlockRepository = readingExamQuestionBlockRepository;
        }
        public void Execute(UpdateReadingExamQuestionBlockCommand command)
        {
            var readingExamQuestionBlock = readingExamQuestionBlockRepository.GetReadingExamQuestionBlock(command.Id);
            readingExamQuestionBlock.TitleSetter(command.Title);
            readingExamQuestionBlock.OrderNo = command.OrderNo;
            readingExamQuestionBlock.DescriptionSetter(command.Description);

            readingExamQuestionBlockRepository.UpdateReadingExamQuestionBlock(readingExamQuestionBlock);
        }
    }
}
