using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ParticipantsAggregate.DataContracts
{
    public class IeltsExamParticipantsQueryFacadeDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid IeltsExamParticipantsStatusId { get; set; }
        public string ExamTitle { get; set; }
        public string UserName { get; set; }
        public Guid IeltsExamId { get; set; }
        public Guid IeltsExamPriceId { get; set; }
        public DateTime RegisterDate { get; set; }
        public string  RegisterDatePersian { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long PriceAmount { get; set; }
        public int? DiscontentAmount { get; set; }
    }
}
