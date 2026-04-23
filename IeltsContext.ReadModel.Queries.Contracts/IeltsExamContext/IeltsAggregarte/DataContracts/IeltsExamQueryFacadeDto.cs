using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.IeltsAggregarte.DataContracts
{
    public class IeltsExamQueryFacadeDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public Guid CustomerId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public DateTime? ActivedDate { get; set; }
        public string ActivedDate_Persian { get; set; }
        public DateTime? DeActivedDate { get; set; }
        public string DeActivedDate_Persian { get; set; }
        public Guid IeltsExamPriceId { get; set; }
        public long PriceAmount { get; set; }
        public int? DiscontentAmount { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public Guid? ListeningExamId { get; set; }
        public Guid? ReadingExamId { get; set; }
        public Guid? SpeakigExamId { get; set; }
        public Guid? WritingExamId { get; set; }
    }
}
