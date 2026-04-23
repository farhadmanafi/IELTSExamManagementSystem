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
    public class UpdateListeningScoreCommandHandler : ICommandHandler<UpdateListeningScoreCommand>
    {
        private readonly IUserResualtRepository userResualtRepository;
        public UpdateListeningScoreCommandHandler(IUserResualtRepository userResualtRepository)
        {
            this.userResualtRepository= userResualtRepository;
        }
        public void Execute(UpdateListeningScoreCommand command)
        {
            var userResult = userResualtRepository.GetUserResualtByIeltsExamId(command.IeltsExamParticipantsId, command.CustomerId);
            userResult.ListeningScore = command.ListeningScore;
            //userResult.FinalScore = 0;//TODO Calculate final score base on new incomming score
            userResualtRepository.UpdateUserResualt(userResult);
        }
    }
}
