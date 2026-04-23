using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Domain.IeltsAggregarte.Services
{
    public interface IIeltsExamPriceRepository
    {
        void AddIeltsExamPrice(IeltsExamPrice ieltsExamPrice);
        void UpdateIeltsExamPrice(IeltsExamPrice ieltsExamPrice);
        IeltsExamPrice GetIeltsExamPriceByExamIeltsExamId(Guid ieltsExamId);
        IeltsExamPrice GetIeltsExamPrice(Guid id);
        IeltsExamPrice GetIeltsExamPriceByExamId(Guid examId);
    }
}
