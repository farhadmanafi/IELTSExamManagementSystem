using ExamContext.Listening.Domain.ListeningUserAnswerAggregate;
using ExamContext.Listening.Domain.ListeningUserAnswerAggregate.Services;
using Framework.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Persistence.ListeningUserAnswerAggregate
{
    public class ListeningUserAnswerRepository : RepositoryBase<ListeningUserAnswer>, IListeningUserAnswerRepository
    {
        public ListeningUserAnswerRepository(IDbContext context) : base(context)
        {

        }

        public void AddListeningUserAnswer(ListeningUserAnswer ListeningUserAnswer)
        {
            Set.Add(ListeningUserAnswer);
        }

        public void DeleteListeningUserAnswer(ListeningUserAnswer ListeningUserAnswer)
        {
            Set.Update(ListeningUserAnswer);
        }

        public ListeningUserAnswer GetListeningUserAnswer(Guid ListeningUserAnswerId)
        {
            return Set.SingleOrDefault(a => a.Id == ListeningUserAnswerId);
        }

        public void UpdateListeningUserAnswer(ListeningUserAnswer ListeningUserAnswer)
        {
            Set.Update(ListeningUserAnswer);
        }
    }
}
