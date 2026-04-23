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
    public class UpdateWritingScoreCommandHandler : ICommandHandler<UpdateWritingScoreCommand>
    {
        private readonly IUserResualtRepository userResualtRepository;
        public UpdateWritingScoreCommandHandler(IUserResualtRepository userResualtRepository)
        {
            this.userResualtRepository = userResualtRepository;
        }
        public void Execute(UpdateWritingScoreCommand command)
        {
            var userResult = userResualtRepository.GetUserResualtByIeltsExamId(command.IeltsExamParticipantsId, command.CustomerId);
            userResult.WritingScore = command.WritingScore;
            //userResult.FinalScore = 0;//TODO Calculate final score base on new incomming score
            userResualtRepository.UpdateUserResualt(userResult);
        }
    }
}
