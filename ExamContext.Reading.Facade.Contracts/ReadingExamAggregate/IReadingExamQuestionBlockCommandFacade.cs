using ExamContext.Reading.Aplication.Contracts.ReadingExamAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Facade.Contracts.ReadingExamAggregate
{
    public interface IReadingExamQuestionBlockCommandFacade
    {
        void AddReadingExamQuestionBlock(AddReadingExamQuestionBlockCommand command);
        void UpdateReadingExamQuestionBlock(UpdateReadingExamQuestionBlockCommand command);
        void DeleteReadingExamQuestionBlock(DeleteReadingExamQuestionBlockCommand command);
    }
}
