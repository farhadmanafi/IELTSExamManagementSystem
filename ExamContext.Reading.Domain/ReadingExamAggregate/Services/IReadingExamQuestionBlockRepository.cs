using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Domain.ReadingExamAggregate.Services
{
    public interface IReadingExamQuestionBlockRepository
    {
        void AddReadingExamQuestionBlock(ReadingExamQuestionBlock readingExamQuestionBlock);
        ReadingExamQuestionBlock GetReadingExamQuestionBlock(Guid readingExamQuestionBlockId);
        void UpdateReadingExamQuestionBlock(ReadingExamQuestionBlock readingExamQuestionBlock);
        void DeleteReadingExamQuestionBlock(ReadingExamQuestionBlock readingExamQuestionBlock);
    }
}
