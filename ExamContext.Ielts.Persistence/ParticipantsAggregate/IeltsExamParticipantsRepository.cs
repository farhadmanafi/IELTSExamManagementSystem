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
    public class IeltsExamParticipantsRepository : RepositoryBase<IeltsExamParticipants>, IIeltsExamParticipantsRepository
    {
        public IeltsExamParticipantsRepository(IDbContext context) : base(context)
        {

        }

        public void AddIeltsExamParticipants(IeltsExamParticipants ieltsExamParticipants)
        {
            Set.Add(ieltsExamParticipants);
        }

        public IeltsExamParticipants GetIeltsExamParticipants(Guid id)
        {
            return Set.SingleOrDefault(a => a.Id == id);
        }

        public void UpdateIeltsExamParticipants(IeltsExamParticipants ieltsExamParticipants)
        {
            Set.Update(ieltsExamParticipants);
        }
    }
}
