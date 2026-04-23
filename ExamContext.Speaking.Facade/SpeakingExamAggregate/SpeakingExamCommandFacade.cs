using ExamContext.Speaking.Aplication.Contracts.SpeakingExamAggregate;
using ExamContext.Speaking.Facade.Contracts.SpeakingExamAggregate;
using Framework.Core.Application;
using Framework.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Speaking.Facade.SpeakingExamAggregate
{
    public class SpeakingExamCommandFacade : FacadeCommandBase, ISpeakingExamCommandFacade
    {
        public SpeakingExamCommandFacade(ICommandBus commandBus) : base(commandBus)
        {

        }

        public void AddSpeakingExam(AddSpeakingExamCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeleteSpeakingExam(DeleteSpeakingExamCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateSpeakingExam(UpdateSpeakingExamCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
