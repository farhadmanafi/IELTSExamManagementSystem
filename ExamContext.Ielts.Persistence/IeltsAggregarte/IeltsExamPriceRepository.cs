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
    public class IeltsExamPriceRepository : RepositoryBase<IeltsExamPrice>, IIeltsExamPriceRepository
    {
        public IeltsExamPriceRepository(IDbContext context) : base(context)
        {

        }

        public void AddIeltsExamPrice(IeltsExamPrice ieltsExamPrice)
        {
            Set.Add(ieltsExamPrice);
        }

        public IeltsExamPrice GetIeltsExamPrice(Guid id)
        {
            return Set.SingleOrDefault(a => a.Id == id);
        }
        public IeltsExamPrice GetIeltsExamPriceByExamIeltsExamId(Guid ieltsExamId)
        {
            return Set.SingleOrDefault(a => a.IeltsExamId == ieltsExamId && a.IsActive == true);
        }

        public IeltsExamPrice GetIeltsExamPriceByExamId(Guid examId)
        {
            return Set.SingleOrDefault(a => a.IeltsExamId == examId);
        }

        public void UpdateIeltsExamPrice(IeltsExamPrice ieltsExamPrice)
        {
            Set.Update(ieltsExamPrice);
        }
    }
}
