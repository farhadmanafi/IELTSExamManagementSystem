using ExamContext.Listening.Domain.ListeningExamAggregate;
using ExamContext.Listening.Domain.ListeningExamAggregate.Services;
using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Persistence.ListeningExamAggregate
{
    public class ListeningExamRepository : RepositoryBase<ListeningExam>, IListeningExamRepository
    {
        public ListeningExamRepository(IDbContext context) : base(context)
        {

        }

        public void AddListeningExam(ListeningExam ListeningExam)
        {
            Set.Add(ListeningExam);
        }

        public void DeleteListeningExam(ListeningExam ListeningExam)
        {
            Set.Update(ListeningExam);
        }

        public ListeningExam GetListeningExam(Guid ListeningExamId)
        {
            return Set.SingleOrDefault(a => a.Id == ListeningExamId);
        }

        public void UpdateListeningExam(ListeningExam ListeningExam)
        {
            Set.Update(ListeningExam);
        }
    }
}
