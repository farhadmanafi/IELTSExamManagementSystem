using ExamContext.Listening.Aplication.Contracts.ListeningExamAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Facade.Contracts.ListeningExamAggregate
{
    public interface IListeningExamCommandFacade
    {
        void AddListeningExam(AddListeningExamCommand command);
        void UpdateListeningExam(UpdateListeningExamCommand command);
        void DeleteListeningExam(DeleteListeningExamCommand command);
    }
}
