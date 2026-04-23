using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Aplication.Contracts.ParticipantsAggregate
{
    public class UpdateIeltsExamParticipantsCommand:Command
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid IeltsExamId { get; set; }
        public Guid IeltsExamPriceId { get; set; }
        public int IeltsExamOrederNumber { get; set; }
        public Guid IeltsExamParticipantsStatusId { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
