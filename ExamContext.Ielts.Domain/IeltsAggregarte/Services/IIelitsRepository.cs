using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Domain.IeltsAggregarte.Services
{
    public interface IIelitsRepository
    {
        void AddIeltsExam(IeltsExam ieltsExam);
        IeltsExam GetIeltsExam(Guid id);
        void UpdateIeltsExam(IeltsExam ieltsExam);
    }
}
