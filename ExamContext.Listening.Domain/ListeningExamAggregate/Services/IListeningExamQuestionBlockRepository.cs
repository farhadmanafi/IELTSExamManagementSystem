using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Domain.ListeningExamAggregate.Services
{
    public interface IListeningExamQuestionBlockRepository
    {
        void AddListeningExamQuestionBlock(ListeningExamQuestionBlock listeningExamQuestionBlock);
        ListeningExamQuestionBlock GetListeningExamQuestionBlock(Guid listeningExamQuestionBlockId);
        void UpdateListeningExamQuestionBlock(ListeningExamQuestionBlock listeningExamQuestionBlock);
        void DeleteListeningExamQuestionBlock(ListeningExamQuestionBlock listeningExamQuestionBlock);
    }
}
