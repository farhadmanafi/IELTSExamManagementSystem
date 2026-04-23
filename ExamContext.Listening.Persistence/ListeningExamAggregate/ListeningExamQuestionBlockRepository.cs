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
    public class ListeningExamQuestionBlockRepository : RepositoryBase<ListeningExamQuestionBlock>, IListeningExamQuestionBlockRepository
    {
        public ListeningExamQuestionBlockRepository(IDbContext context) : base(context)
        {

        }

        public void AddListeningExamQuestionBlock(ListeningExamQuestionBlock ListeningExamQuestionBlock)
        {
            Set.Add(ListeningExamQuestionBlock);
        }

        public void DeleteListeningExamQuestionBlock(ListeningExamQuestionBlock ListeningExamQuestionBlock)
        {
            Set.Update(ListeningExamQuestionBlock);
        }

        public ListeningExamQuestionBlock GetListeningExamQuestionBlock(Guid ListeningExamQuestionBlockId)
        {
            return Set.SingleOrDefault(a => a.Id == ListeningExamQuestionBlockId);
        }

        public void UpdateListeningExamQuestionBlock(ListeningExamQuestionBlock ListeningExamQuestionBlock)
        {
            Set.Update(ListeningExamQuestionBlock);
        }
    }
}
