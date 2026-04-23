using ExamContext.Writing.Aplication.Contracts.WritingExamAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Writing.Facade.Contracts.WritingExamAggregate
{
    public interface IWritingExamSectionCommandFacade
    {
        void AddWritingExamSection(AddWritingExamSectionCommand command);
        void UpdateWritingExamSection(UpdateWritingExamSectionCommand command);
        void DeleteWritingExamSection(DeleteWritingExamSectionCommand command);
    }
}
