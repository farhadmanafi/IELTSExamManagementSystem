using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Domain.ListeningQuestionAggregate.Services
{
    public interface IListeningQuestionRepository
    {
        void AddListeningQuestion(ListeningQuestion listeningQuestion);
        ListeningQuestion GetListeningQuestion(Guid listeningQuestionId);
        void UpdateListeningQuestion(ListeningQuestion listeningQuestion);
        void DeleteListeningQuestion(ListeningQuestion listeningQuestion);
    }
}
