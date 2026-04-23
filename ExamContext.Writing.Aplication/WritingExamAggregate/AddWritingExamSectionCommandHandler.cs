using ExamContext.Writing.Aplication.Contracts.WritingExamAggregate;
using ExamContext.Writing.Domain.Contracts.WritingExamAggregate;
using ExamContext.Writing.Domain.WritingExamAggregate;
using ExamContext.Writing.Domain.WritingExamAggregate.Services;
using Framework.Application;
using Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Writing.Aplication.WritingExamAggregate
{
    public class AddWritingExamSectionCommandHandler : ICommandHandler<AddWritingExamSectionCommand>
    {
        private readonly IWritingExamSectionRepository writingExamSectionRepository;
        public AddWritingExamSectionCommandHandler(IWritingExamSectionRepository writingExamSectionRepository)
        {
            this.writingExamSectionRepository = writingExamSectionRepository;
        }
        public void Execute(AddWritingExamSectionCommand command)
        {
            var writingExamSectionDto = Mapper.Map<AddWritingExamSectionCommand, WritingExamSectionDto>(command);
            var writingExamSection = new WritingExamSection(writingExamSectionDto);

            writingExamSectionRepository.AddWritingExamSection(writingExamSection);
        }
    }
}
