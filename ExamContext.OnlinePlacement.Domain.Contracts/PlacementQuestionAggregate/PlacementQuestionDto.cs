using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Domain.Contracts.PlacementQuestionAggregate
{
    public class PlacementQuestionDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Guid PlacementExamtId { get; set; }

        public Guid PlacementQuestionTypeId { get; set; }
    }
}
