using ExamContext.Reading.Aplication.Contracts.ReadingExamAggregate;
using ExamContext.Reading.Domain.Contracts.ReadingExamAggregate;
using ExamContext.Reading.Domain.ReadingExamAggregate;
using ExamContext.Reading.Domain.ReadingExamAggregate.Services;
using Framework.Application;
using Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Aplication.ReadingExamAggregate
{
    public class AddReadingExamCommandHandler : ICommandHandler<AddReadingExamCommand>
    {
        private readonly IReadingExamRepository readingExamRepository;
        public AddReadingExamCommandHandler(IReadingExamRepository readingExamRepository)
        {
            this.readingExamRepository = readingExamRepository;
        }
        public void Execute(AddReadingExamCommand command)
        {
            var readingExamDto = Mapper.Map<AddReadingExamCommand, ReadingExamDto>(command);
            var readingExam = new ReadingExam(readingExamDto);

            readingExamRepository.AddReadingExam(readingExam);
        }
    }   
}
