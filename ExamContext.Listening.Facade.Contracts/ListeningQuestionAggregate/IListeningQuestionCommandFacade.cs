using ExamContext.Listening.Aplication.Contracts.ListeningQuestionAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Facade.Contracts.ListeningQuestionAggregate
{
    public interface IListeningQuestionCommandFacade
    {
        void AddListeningQuestion(AddListeningQuestionCommand command);
        void UpdateListeningQuestion(UpdateListeningQuestionCommand command);
        void DeleteListeningQuestion(DeleteListeningQuestionCommand command);
    }
}
