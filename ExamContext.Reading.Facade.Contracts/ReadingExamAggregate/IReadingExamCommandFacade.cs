using ExamContext.Reading.Aplication.Contracts.ReadingExamAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamContext.Reading.Facade.Contracts.ReadingExamAggregate
{
    public interface IReadingExamCommandFacade
    {
        void AddReadingExam(AddReadingExamCommand command);
        void UpdateReadingExam(UpdateReadingExamCommand command);
        void DeleteReadingExam(DeleteReadingExamCommand command);
    }
}
