using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Writing.Domain.WritingUserAnswerAggregate.Services
{
    public interface IWritingUserAnswerRepository
    {
        void AddWritingUserAnswer(WritingUserAnswer writingUserAnswer);
        WritingUserAnswer GetWritingUserAnswer(Guid writingUserAnswerId);
        void UpdateWritingUserAnswer(WritingUserAnswer writingUserAnswer);
        void DeleteWritingUserAnswer(WritingUserAnswer writingUserAnswer);
    }
}
