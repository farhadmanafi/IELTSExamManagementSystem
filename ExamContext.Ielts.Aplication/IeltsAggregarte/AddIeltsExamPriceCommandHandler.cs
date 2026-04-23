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
    public class AddIeltsExamPriceCommandHandler : ICommandHandler<AddIeltsExamPriceCommand>
    {
        private readonly IIeltsExamPriceRepository iieltsExamPriceRepository;
        public AddIeltsExamPriceCommandHandler(IIeltsExamPriceRepository iieltsExamPriceRepository)
        {
            this.iieltsExamPriceRepository = iieltsExamPriceRepository;
        }
        public void Execute(AddIeltsExamPriceCommand command)
        {
            var oldIeltsExam = iieltsExamPriceRepository.GetIeltsExamPriceByExamIeltsExamId(command.IeltsExamId);
            if (oldIeltsExam != null)
            {
                oldIeltsExam.DeactivedDate = DateTime.Now;
                oldIeltsExam.IsActive = false;
                iieltsExamPriceRepository.UpdateIeltsExamPrice(oldIeltsExam);
            }
            var ieltsExamPriceDto = Mapper.Map<AddIeltsExamPriceCommand, IeltsExamPriceDto>(command);
            var ieltsExamPrice = new IeltsExamPrice(ieltsExamPriceDto);

            iieltsExamPriceRepository.AddIeltsExamPrice(ieltsExamPrice);
        }
    }
}
