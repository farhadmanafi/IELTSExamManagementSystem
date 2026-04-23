using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Writing.Domain.WritingExamAggregate.Services
{
    public interface IWritingExamSectionRepository
    {
        void AddWritingExamSection(WritingExamSection writingExamSection);
        WritingExamSection GetWritingExamSection(Guid writingExamSectionId);
        void UpdateWritingExamSection(WritingExamSection writingExamSection);
        void DeleteWritingExamSection(WritingExamSection writingExamSection);
    }
}
