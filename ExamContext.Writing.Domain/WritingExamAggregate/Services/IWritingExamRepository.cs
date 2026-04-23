using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Writing.Domain.WritingExamAggregate.Services
{
    public interface IWritingExamRepository
    {
        void AddWritingExam(WritingExam writingExam);
        WritingExam GetWritingExam(Guid writingExamId);
        void UpdateWritingExam(WritingExam writingExam);
        void DeleteWritingExam(WritingExam writingExam);
    }
}
