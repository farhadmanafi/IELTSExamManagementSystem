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
    public class UpdateReadingQuestionTypeCommandHandler : ICommandHandler<UpdateReadingQuestionTypeCommand>
    {
        private readonly IReadingQuestionTypeRepository readingQuestionTypeRepository;
        public UpdateReadingQuestionTypeCommandHandler(IReadingQuestionTypeRepository readingQuestionTypeTypeRepository)
        {
            this.readingQuestionTypeRepository = readingQuestionTypeTypeRepository;
        }
        public void Execute(UpdateReadingQuestionTypeCommand command)
        {
            var ReadingQuestionTypeType = readingQuestionTypeRepository.GetReadingQuestionType(command.Id);
            //Changest

            readingQuestionTypeRepository.UpdateReadingQuestionType(ReadingQuestionTypeType);
        }
    }
}
