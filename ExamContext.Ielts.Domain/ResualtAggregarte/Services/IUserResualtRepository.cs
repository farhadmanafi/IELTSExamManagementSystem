using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Domain.ResualtAggregarte.Services
{
    public interface IUserResualtRepository
    {
        void AddUserResualt(UserResualt userResualt);
        UserResualt GetUserResualt(Guid id);
        void UpdateUserResualt(UserResualt userResualt);
        UserResualt GetUserResualtByIeltsExamId(Guid ieltsExamParticipantsId, Guid customerId);
    }
}
