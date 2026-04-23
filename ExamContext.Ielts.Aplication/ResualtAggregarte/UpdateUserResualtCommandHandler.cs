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
    public class UpdateUserResualtCommandHandler : ICommandHandler<UpdateUserResualtCommand>
    {
        private readonly IUserResualtRepository userResualtRepository;
        public UpdateUserResualtCommandHandler(IUserResualtRepository userResualtRepository)
        {
            this.userResualtRepository = userResualtRepository;
        }
        public void Execute(UpdateUserResualtCommand command)
        {
            var ieltsExam = userResualtRepository.GetUserResualt(command.Id);
            //Changest

            userResualtRepository.UpdateUserResualt(ieltsExam);
        }
    }
}
