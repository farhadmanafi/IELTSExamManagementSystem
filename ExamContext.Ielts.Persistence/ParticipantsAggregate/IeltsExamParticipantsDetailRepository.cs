using ExamContext.Ielts.Domain.ParticipantsAggregate;
using ExamContext.Ielts.Domain.ParticipantsAggregate.Services;
using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Persistence.ParticipantsAggregate
{
    public class IeltsExamParticipantsDetailRepository : RepositoryBase<IeltsExamParticipantsDetail>, IIeltsExamParticipantsDetailRepository
    {
        public IeltsExamParticipantsDetailRepository(IDbContext context) : base(context)
        {

        }
        public void AddIeltsExamParticipantsDetail(IeltsExamParticipantsDetail ieltsExamParticipantsDetail)
        {
            Set.Add(ieltsExamParticipantsDetail);
        }

        public IeltsExamParticipantsDetail GetIeltsExamParticipantsDetail(Guid id)
        {
            return Set.SingleOrDefault(a => a.Id == id);
        }

        public void UpdateIeltsExamParticipantsDetail(IeltsExamParticipantsDetail ieltsExamParticipantsDetail)
        {
            Set.Update(ieltsExamParticipantsDetail);
        }
    }
}
