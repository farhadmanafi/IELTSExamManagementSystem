using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.ParticipantsAggregate.DataContracts
{
    public class OnlinePlacementParticipantsQueryFacadeDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid OnlinePlacementParticipantsStatusId { get; set; }
        public string ExamTitle { get; set; }
        public string UserName { get; set; }
        public Guid OnlinePlacementId { get; set; }
        public Guid OnlinePlacementPriceId { get; set; }
        public DateTime RegisterDate { get; set; }
        public string  RegisterDatePersian { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public long PriceAmount { get; set; }
        public int? DiscontentAmount { get; set; }
    }
}
