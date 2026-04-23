using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Aplication.Contracts.ListeningUserAnswerAggregate
{
    public class AddListeningUserAnswerCommand:Command
    {
        public Guid ListeningExamId { get; set; }
        public Guid IeltsExamParticipantId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid? AnswerId { get; set; }
        public string AnswerText { get; set; }
        public Guid CustomerId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
