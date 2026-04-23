using ExamContext.Ielts.Aplication.Contracts.ResualtAggregarte;
using ExamContext.Ielts.Domain.Contracts.ResualtAggregarte;
using ExamContext.Ielts.Domain.ResualtAggregarte;
using ExamContext.Ielts.Domain.ResualtAggregarte.Services;
using Framework.Application;
using Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Aplication.ResualtAggregarte
{
    public class AddUserResualtCommandHandler : ICommandHandler<AddUserResualtCommand>
    {
        private readonly IUserResualtRepository userResualtRepository;
        public AddUserResualtCommandHandler(IUserResualtRepository userResualtRepository)
        {
            this.userResualtRepository = userResualtRepository;
        }
        public void Execute(AddUserResualtCommand command)
        {
            var userResualDto = Mapper.Map<AddUserResualtCommand, UserResualtDto>(command);
            var ieltsExam = new UserResualt(userResualDto);

            userResualtRepository.AddUserResualt(ieltsExam);
        }
    }
}
