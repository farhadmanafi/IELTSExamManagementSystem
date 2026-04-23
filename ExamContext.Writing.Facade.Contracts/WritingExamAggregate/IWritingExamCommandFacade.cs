using ExamContext.Writing.Aplication.Contracts.WritingExamAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Writing.Facade.Contracts.WritingExamAggregate
{
    public interface IWritingExamCommandFacade
    {
        void AddWritingExam(AddWritingExamCommand command);
        void UpdateWritingExam(UpdateWritingExamCommand command);
        void DeleteWritingExam(DeleteWritingExamCommand command);
    }
}
