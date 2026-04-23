using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.WritingContext.WritingUserAnswerAggregate.DataContracts
{
    public class WritingUserAnswerQueryFacadeDto
    {
        public Guid Id { get; set; }
        public Guid WritingExamSectionId { get; set; }
        public Guid IeltsExamParticipantId { get; set; }
        public string AnswerText { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime RegisterDateTime { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
