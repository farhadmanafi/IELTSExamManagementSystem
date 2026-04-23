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
    public class IeltsExamCommandFacade : FacadeCommandBase, IIeltsExamCommandFacade
    {
        public IeltsExamCommandFacade(ICommandBus commandBus) : base(commandBus)
        {

        }
        public void AddIeltsExam(AddIeltsExamCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeleteIeltsExam(DeleteIeltsExamCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateIeltsExam(UpdateIeltsExamCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
