using ExamContext.Ielts.Aplication.Contracts.ResualtAggregarte;
using ExamContext.Ielts.Domain.ResualtAggregarte.Services;
using Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Aplication.ResualtAggregarte
{
    public class UpdateSpeakingScoreCommandHandler : ICommandHandler<UpdateSpeakingScoreCommand>
    {
        private readonly IUserResualtRepository userResualtRepository;
        public UpdateSpeakingScoreCommandHandler(IUserResualtRepository userResualtRepository)
        {
            this.userResualtRepository = userResualtRepository;
        }
        public void Execute(UpdateSpeakingScoreCommand command)
        {
            var userResult = userResualtRepository.GetUserResualtByIeltsExamId(command.IeltsExamParticipantsId, command.CustomerId);
            userResult.SpeakingScore = command.SpeakingScore;
            //userResult.FinalScore = 0;//TODO Calculate final score base on new incomming score
            userResualtRepository.UpdateUserResualt(userResult);
        }
    }
}
