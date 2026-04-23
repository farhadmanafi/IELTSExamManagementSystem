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
    public class DeleteUserResualtCommandHandler : ICommandHandler<DeleteUserResualtCommand>
    {
        private readonly IUserResualtRepository userResualtRepository;
        public DeleteUserResualtCommandHandler(IUserResualtRepository userResualtRepository)
        {
            this.userResualtRepository = userResualtRepository;
        }
        public void Execute(DeleteUserResualtCommand command)
        {
            var userResualt = userResualtRepository.GetUserResualt(command.Id);
            userResualt.IsDeleted = true;
            userResualt.IsActive = false;

            userResualtRepository.UpdateUserResualt(userResualt);
        }
    }
}
