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
    public class UpdateReadingQuestionCommandHandler : ICommandHandler<UpdateReadingQuestionCommand>
    {
        private readonly IReadingQuestionRepository readingQuestionRepository;
        public UpdateReadingQuestionCommandHandler(IReadingQuestionRepository readingQuestionRepository)
        {
            this.readingQuestionRepository = readingQuestionRepository;
        }
        public void Execute(UpdateReadingQuestionCommand command)
        {
            var ReadingQuestion = readingQuestionRepository.GetReadingQuestion(command.Id);
            ReadingQuestion.TitleSetter(command.Title);
            ReadingQuestion.DescriptionSetter(command.Description);
            ReadingQuestion.OrderNo = command.OrderNo;
            ReadingQuestion.ReadingQuestionTypeId = command.ReadingQuestionTypeId;
            ReadingQuestion.ReadingExamSectionId = command.ReadingExamSectionId;
            ReadingQuestion.ReadingExamQuestionBlockId = command.ReadingExamQuestionBlockId;
            ReadingQuestion.IsActive = command.IsActive;

            readingQuestionRepository.UpdateReadingQuestion(ReadingQuestion);
        }
    }
}
