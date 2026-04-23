using ExamContext.Listening.Aplication.Contracts.ListeningExamAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Facade.Contracts.ListeningExamAggregate
{
    public interface IListeningExamQuestionBlockCommandFacade
    {
        void AddListeningExamQuestionBlock(AddListeningExamQuestionBlockCommand command);
        void UpdateListeningExamQuestionBlock(UpdateListeningExamQuestionBlockCommand command);
        void DeleteListeningExamQuestionBlock(DeleteListeningExamQuestionBlockCommand command);
    }
}
