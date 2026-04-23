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
    public class ListeningQuestionAnswersRepository : RepositoryBase<ListeningQuestionAnswers>, IListeningQuestionAnswersRepository
    {
        public ListeningQuestionAnswersRepository(IDbContext context) : base(context)
        {

        }

        public void AddListeningQuestionAnswers(ListeningQuestionAnswers ListeningQuestionAnswers)
        {
            Set.Add(ListeningQuestionAnswers);
        }

        public void DeleteListeningQuestionAnswers(ListeningQuestionAnswers ListeningQuestionAnswers)
        {
            Set.Update(ListeningQuestionAnswers);
        }

        public ListeningQuestionAnswers GetListeningQuestionAnswers(Guid ListeningQuestionAnswersId)
        {
            return Set.SingleOrDefault(a => a.Id == ListeningQuestionAnswersId);
        }

        public void UpdateListeningQuestionAnswers(ListeningQuestionAnswers ListeningQuestionAnswers)
        {
            Set.Update(ListeningQuestionAnswers);
        }
    }
}
