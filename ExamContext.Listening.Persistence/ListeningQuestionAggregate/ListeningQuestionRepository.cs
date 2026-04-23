using ExamContext.Listening.Domain.ListeningQuestionAggregate;
using ExamContext.Listening.Domain.ListeningQuestionAggregate.Services;
using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Persistence.ListeningQuestionAggregate
{
    public class ListeningQuestionRepository : RepositoryBase<ListeningQuestion>, IListeningQuestionRepository
    {
        public ListeningQuestionRepository(IDbContext context) : base(context)
        {

        }

        public void AddListeningQuestion(ListeningQuestion ListeningQuestion)
        {
            Set.Add(ListeningQuestion);
        }

        public void DeleteListeningQuestion(ListeningQuestion ListeningQuestion)
        {
            Set.Update(ListeningQuestion);
        }

        public ListeningQuestion GetListeningQuestion(Guid ListeningQuestionId)
        {
            return Set.SingleOrDefault(a => a.Id == ListeningQuestionId);
        }

        public void UpdateListeningQuestion(ListeningQuestion ListeningQuestion)
        {
            Set.Update(ListeningQuestion);
        }
    }
}
