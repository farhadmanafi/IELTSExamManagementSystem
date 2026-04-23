using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Domain.ListeningExamAggregate.Services
{
    public interface IListeningExamRepository
    {
        void AddListeningExam(ListeningExam listeningExam);
        ListeningExam GetListeningExam(Guid listeningExamId);
        void UpdateListeningExam(ListeningExam listeningExam);
        void DeleteListeningExam(ListeningExam listeningExam);
    }
}
