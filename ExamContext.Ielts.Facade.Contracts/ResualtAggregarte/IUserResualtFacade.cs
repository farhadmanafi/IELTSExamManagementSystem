using ExamContext.Ielts.Aplication.Contracts.ResualtAggregarte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Facade.Contracts.ResualtAggregarte
{
    public interface IUserResualtFacade
    {
        void AddUserResualt(AddUserResualtCommand command);
        void UpdateUserResualt(UpdateUserResualtCommand command);
        void DeleteUserResualt(DeleteUserResualtCommand command);
        void UpdateListeningScore(UpdateListeningScoreCommand command);
        void UpdateReadingScore(UpdateReadingScoreCommand command);
        void UpdateSpeakingScore(UpdateSpeakingScoreCommand command);
        void UpdateWritingScore(UpdateWritingScoreCommand command);
    }
}
