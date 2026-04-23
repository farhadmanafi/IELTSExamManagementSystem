using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementExamAggregate.DataContracts
{
    public class PlacementExamQueryFacadeDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CustomerId { get; set; }
        public string UserName { get; set; }
        public DateTime? ActivedDate { get; set; }
        public string ActivedDate_Persian { get; set; }
        public DateTime? DeActivedDate { get; set; }
        public Guid PlacementExamPriceId { get; set; }
        public long PriceAmount { get; set; }
        public int? DiscontentAmount { get; set; }
        public string DeActivedDate_Persian { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
