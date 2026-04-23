using ExamContext.Ielts.Aplication.Contracts.ResualtAggregarte;
using ExamContext.Ielts.Facade.Contracts.ResualtAggregarte;
using Framework.Core.Application;
using Framework.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Facade.ResualtAggregarte
{
    public class UserResualtFacade : FacadeCommandBase, IUserResualtFacade
    {
        public UserResualtFacade(ICommandBus commandBus) : base(commandBus)
        {

        }

        public void AddUserResualt(AddUserResualtCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void DeleteUserResualt(DeleteUserResualtCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateListeningScore(UpdateListeningScoreCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateReadingScore(UpdateReadingScoreCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateSpeakingScore(UpdateSpeakingScoreCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateUserResualt(UpdateUserResualtCommand command)
        {
            CommandBus.Dispatch(command);
        }

        public void UpdateWritingScore(UpdateWritingScoreCommand command)
        {
            CommandBus.Dispatch(command);
        }
    }
}
