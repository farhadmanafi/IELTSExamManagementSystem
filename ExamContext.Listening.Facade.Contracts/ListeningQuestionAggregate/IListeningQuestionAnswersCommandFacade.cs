using ExamContext.Listening.Aplication.Contracts.ListeningQuestionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Facade.Contracts.ListeningQuestionAggregate
{
    public interface IListeningQuestionAnswersCommandFacade
    {
        void AddListeningQuestionAnswers(AddListeningQuestionAnswersCommand command);
        void UpdateListeningQuestionAnswers(UpdateListeningQuestionAnswersCommand command);
        void DeleteListeningQuestionAnswers(DeleteListeningQuestionAnswersCommand command);
    }
}
