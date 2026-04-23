using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Domain.ListeningExamAggregate.Services
{
    public interface IListeningExamSectionRepository
    {
        void AddListeningExamSection(ListeningExamSection ListeningExamSection);
        ListeningExamSection GetListeningExamSection(Guid listeningExamSectionId);
        void UpdateListeningExamSection(ListeningExamSection listeningExamSection);
        void DeleteListeningExamSection(ListeningExamSection listeningExamSection);
    }
}
