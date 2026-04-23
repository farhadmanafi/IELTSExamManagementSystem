using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.IeltsAggregarte.DataContracts
{
    public class IeltsExamPriceQueryFacadeDto
    {
        public Guid Id { get; set; }
        public long PriceAmount { get; set; }
        public int? DiscontentAmount { get; set; }
        public DateTime? ActivedDate { get; set; }
        public DateTime? DeactivedDate { get; set; }
        public string DeActivedDate_Persian { get; set; }
        public string ActivedDate_Persian { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public Guid IeltsExamId { get; set; }
    }
}
