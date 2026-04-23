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
    public class AddWritingExamCommandHandler : ICommandHandler<AddWritingExamCommand>
    {
        private readonly IWritingExamRepository writingExamRepository;
        public AddWritingExamCommandHandler(IWritingExamRepository writingExamRepository)
        {
            this.writingExamRepository = writingExamRepository;
        }
        public void Execute(AddWritingExamCommand command)
        {
            var writingExamDto = Mapper.Map<AddWritingExamCommand, WritingExamDto>(command);
            var writingExam = new WritingExam(writingExamDto);

            writingExamRepository.AddWritingExam(writingExam);
        }
    }
}
