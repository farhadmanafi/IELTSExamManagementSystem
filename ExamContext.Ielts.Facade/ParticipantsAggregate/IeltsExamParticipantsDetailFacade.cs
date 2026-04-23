using ExamContext.Ielts.Aplication.Contracts.ParticipantsAggregate;
using ExamContext.Ielts.Facade.Contracts.ParticipantsAggregate;
using Framework.Core.Application;
using Framework.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Facade.ParticipantsAggregate
{
    public class IeltsExamParticipantsDetailFacade : FacadeCommandBase, IIeltsExamParticipantsDetailFacade
    {
        public IeltsExamParticipantsDetailFacade(ICommandBus commandBus) : base(commandBus)
        {

        }
        public void AddIeltsExamParticipantsDetail(AddIeltsExamParticipantsDetailCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateIeltsExamParticipantsDetail(UpdateIeltsExamParticipantsDetailCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
