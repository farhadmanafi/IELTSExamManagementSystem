using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Domain.Contracts.ParticipantsAggregate
{
    public class IeltsExamParticipantsDto
    {
        public Guid CustomerId { get; set; }
        public Guid IeltsExamId { get; set; }
        public Guid IeltsExamPriceId { get; set; }
        public int IeltsExamOrederNumber { get; set; }
        public DateTime RegisterDate { get; set; }
        public Guid IeltsExamParticipantsStatusId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
