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
    public class ListeningExamSectionRepository : RepositoryBase<ListeningExamSection>, IListeningExamSectionRepository
    {
        public ListeningExamSectionRepository(IDbContext context) : base(context)
        {

        }
        public void AddListeningExamSection(ListeningExamSection ListeningExamSection)
        {
            Set.Add(ListeningExamSection);
        }

        public void DeleteListeningExamSection(ListeningExamSection listeningExamSection)
        {
            Set.Update(listeningExamSection);
        }

        public ListeningExamSection GetListeningExamSection(Guid listeningExamSectionId)
        {
            return Set.SingleOrDefault(a => a.Id == listeningExamSectionId);
        }

        public void UpdateListeningExamSection(ListeningExamSection listeningExamSection)
        {
            Set.Update(listeningExamSection);
        }
    }
}
