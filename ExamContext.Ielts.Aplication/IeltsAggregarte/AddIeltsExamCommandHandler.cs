using ExamContext.Ielts.Aplication.Contracts.IeltsAggregarte;
using ExamContext.Ielts.Domain.Contracts.IeltsAggregarte;
using ExamContext.Ielts.Domain.IeltsAggregarte;
using ExamContext.Ielts.Domain.IeltsAggregarte.Services;
using Framework.Application;
using Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Aplication.IeltsAggregarte
{
    public class AddIeltsExamCommandHandler : ICommandHandler<AddIeltsExamCommand>
    {
        private readonly IIelitsRepository _iIelitsRepository;
        public AddIeltsExamCommandHandler(IIelitsRepository iIelitsRepository)
        {
            _iIelitsRepository = iIelitsRepository;
        }
        public void Execute(AddIeltsExamCommand command)
        {
            var ieltsExamDto = Mapper.Map<AddIeltsExamCommand, IeltsExamDto>(command);
            var ieltsExam = new IeltsExam(ieltsExamDto);

            _iIelitsRepository.AddIeltsExam(ieltsExam);
        }
    }
}
