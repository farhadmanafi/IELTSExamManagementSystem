using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Domain.ListeningQuestionAggregate.Services
{
    public interface IListeningQuestionAnswersRepository
    {
        void AddListeningQuestionAnswers(ListeningQuestionAnswers listeningQuestionAnswers);
        ListeningQuestionAnswers GetListeningQuestionAnswers(Guid listeningQuestionAnswersId);
        void UpdateListeningQuestionAnswers(ListeningQuestionAnswers listeningQuestionAnswers);
        void DeleteListeningQuestionAnswers(ListeningQuestionAnswers listeningQuestionAnswers);
    }
}
