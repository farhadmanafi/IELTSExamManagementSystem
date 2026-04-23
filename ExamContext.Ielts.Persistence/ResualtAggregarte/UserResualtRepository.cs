using ExamContext.Ielts.Domain.ResualtAggregarte;
using ExamContext.Ielts.Domain.ResualtAggregarte.Services;
using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Persistence.ResualtAggregarte
{
    public class UserResualtRepository : RepositoryBase<UserResualt>, IUserResualtRepository
    {
        public UserResualtRepository(IDbContext context) : base(context)
        {

        }

        public void AddUserResualt(UserResualt userResualt)
        {
            Set.Add(userResualt);
        }

        public UserResualt GetUserResualt(Guid id)
        {
            return Set.SingleOrDefault(a => a.Id == id);
        }

        public UserResualt GetUserResualtByIeltsExamId(Guid ieltsExamParticipantsId, Guid customerId)
        {
            return Set.SingleOrDefault(a=>a.ParticipantsId == ieltsExamParticipantsId & a.CustomerId==customerId);
        }

        public void UpdateUserResualt(UserResualt userResualt)
        {
            Set.Update(userResualt);
        }
    }
}
