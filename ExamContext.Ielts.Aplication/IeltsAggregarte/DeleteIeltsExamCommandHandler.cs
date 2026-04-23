using ExamContext.Ielts.Aplication.Contracts.IeltsAggregarte;
using ExamContext.Ielts.Domain.IeltsAggregarte.Services;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Aplication.IeltsAggregarte
{
    public class DeleteIeltsExamCommandHandler : ICommandHandler<DeleteIeltsExamCommand>
    {
        private readonly IIelitsRepository iIelitsRepository;
        public DeleteIeltsExamCommandHandler(IIelitsRepository iIelitsRepository)
        {
            this.iIelitsRepository = iIelitsRepository;
        }
        public void Execute(DeleteIeltsExamCommand command)
        {
            var ieltsExam = iIelitsRepository.GetIeltsExam(command.Id);
            ieltsExam.IsDeleted = true;
            ieltsExam.IsActive = false;

            iIelitsRepository.UpdateIeltsExam(ieltsExam);
        }
    }
}
