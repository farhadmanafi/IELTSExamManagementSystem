using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Writing.Aplication.Contracts.WritingUserAnswerAggregate
{
    public class UpdateWritingUserAnswerCommand:Command
    {
        public Guid Id { get; set; }
        public Guid WritingExamId { get; set; }
        public Guid IeltsExamParticipantId { get; set; }
        public string AnswerText { get; set; }
        public Guid UserId { get; set; }
        public DateTime RegisterDateTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
