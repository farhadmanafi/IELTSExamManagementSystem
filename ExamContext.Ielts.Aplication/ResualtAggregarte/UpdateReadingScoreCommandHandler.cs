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
    public class UpdateReadingScoreCommandHandler : ICommandHandler<UpdateReadingScoreCommand>
    {
        private readonly IUserResualtRepository userResualtRepository;
        public UpdateReadingScoreCommandHandler(IUserResualtRepository userResualtRepository)
        {
            this.userResualtRepository = userResualtRepository;
        }
        public void Execute(UpdateReadingScoreCommand command)
        {
            var userResult = userResualtRepository.GetUserResualtByIeltsExamId(command.IeltsExamParticipantsId, command.CustomerId);
            userResult.ReadingScore = command.ReadingScore;
            //userResult.FinalScore = 0;//TODO Calculate final score base on new incomming score
            userResualtRepository.UpdateUserResualt(userResult);
        }
    }
}
