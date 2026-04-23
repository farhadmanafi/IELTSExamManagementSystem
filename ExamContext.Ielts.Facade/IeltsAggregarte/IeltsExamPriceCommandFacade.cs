using ExamContext.Ielts.Aplication.Contracts.IeltsAggregarte;
using ExamContext.Ielts.Facade.Contracts.IeltsAggregarte;
using Framework.Core.Application;
using Framework.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Facade.IeltsAggregarte
{
    public class IeltsExamPriceCommandFacade : FacadeCommandBase, IIeltsExamPriceCommandFacade
    {
        public IeltsExamPriceCommandFacade(ICommandBus commandBus) : base(commandBus)
        {

        }
        public void AddIeltsExamPrice(AddIeltsExamPriceCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
