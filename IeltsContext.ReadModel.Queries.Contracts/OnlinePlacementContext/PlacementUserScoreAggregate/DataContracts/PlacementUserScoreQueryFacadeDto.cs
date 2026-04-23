using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementUserScoreAggregate.DataContracts
{
    public class PlacementUserScoreQueryFacadeDto
    {
        public Guid Id { get; set; }
        public Guid PlacementExamId { get; set; }
        public string PlacementExamTitle { get; set; }
        public Guid CustomerId { get; set; }
        public string UserName { get; set; }
        public Guid LevelScoreId { get; set; }
        public string LevelScoreName { get; set; }
        public DateTime ExamDate { get; set; }
        public string ExamDate_Persian { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
