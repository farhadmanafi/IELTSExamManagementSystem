using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Aplication.Contracts.PlacementUserScoreAggregate
{
    public class AddPlacementUserScoreCommand : Command
    {
        public Guid PlacementExamId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid LevelScoreId { get; set; }
        public DateTime ExamDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
