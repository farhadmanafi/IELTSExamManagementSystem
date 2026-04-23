using ExamContext.Listening.Aplication.Contracts.ListeningUserAnswerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Facade.Contracts.ListeningUserAnswerAggregate
{
    public interface IListeningUserAnswerCommandFacade
    {
        void ListeningUserAnswer(ListeningUserAnswerCommand command);
        void AddListeningUserAnswer(AddListeningUserAnswerCommand command);
        void UpdateListeningUserAnswer(UpdateListeningUserAnswerCommand command);
        void DeleteListeningUserAnswer(DeleteListeningUserAnswerCommand command);
    }
}
