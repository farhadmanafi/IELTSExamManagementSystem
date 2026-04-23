using ExamContext.Reading.Aplication.Contracts.ReadingExamAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Facade.Contracts.ReadingExamAggregate
{
    public interface IReadingExamSectionCommandFacade
    {
        void AddReadingExamSection(AddReadingExamSectionCommand command);
        void UpdateReadingExamSection(UpdateReadingExamSectionCommand command);
        void DeleteReadingExamSection(DeleteReadingExamSectionCommand command);
    }
}
