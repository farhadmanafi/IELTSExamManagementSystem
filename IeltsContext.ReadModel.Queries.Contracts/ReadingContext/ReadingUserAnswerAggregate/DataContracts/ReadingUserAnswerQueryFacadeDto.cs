using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingUserAnswerAggregate.DataContracts
{
    public class ReadingUserAnswerQueryFacadeDto
    {
        public Guid Id { get; set; }
        public Guid ReadingExamId { get; set; }
        public Guid IeltsExamParticipantId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid? AnswerId { get; set; }
        public string AnswerText { get; set; }
        public Guid CustomerId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string QuestionTitle { get; set; }
        public string AnswerTitle { get; set; }
        public bool? IsCorrectAnswer { get; set; }
    }
}
