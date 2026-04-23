using ExamContext.Ielts.Aplication.Contracts.IeltsAggregarte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Facade.Contracts.IeltsAggregarte
{
    public interface IIeltsExamPriceCommandFacade
    {
        void AddIeltsExamPrice(AddIeltsExamPriceCommand command);
    }
}
