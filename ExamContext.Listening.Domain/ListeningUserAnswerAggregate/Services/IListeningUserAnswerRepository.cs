using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Domain.ListeningUserAnswerAggregate.Services
{
    public interface IListeningUserAnswerRepository
    {
        void AddListeningUserAnswer(ListeningUserAnswer listeningUserAnswer);
        ListeningUserAnswer GetListeningUserAnswer(Guid listeningUserAnswerId);
        void UpdateListeningUserAnswer(ListeningUserAnswer listeningUserAnswer);
        void DeleteListeningUserAnswer(ListeningUserAnswer listeningUserAnswer);
    }
}
