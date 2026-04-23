using ExamContext.Ielts.Domain.IeltsAggregarte;
using ExamContext.Ielts.Domain.IeltsAggregarte.Services;
using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Persistence.IeltsAggregarte
{
    public class IelitsRepository : RepositoryBase<IeltsExam>, IIelitsRepository
    {
        public IelitsRepository(IDbContext context) : base(context)
        {

        }
        public void AddIeltsExam(IeltsExam ieltsExam)
        {
            Set.Add(ieltsExam);
        }

        public IeltsExam GetIeltsExam(Guid id)
        {
            return Set.SingleOrDefault(a => a.Id == id);
        }

        public void UpdateIeltsExam(IeltsExam ieltsExam)
        {
            Set.Update(ieltsExam);
        }
    }
}
