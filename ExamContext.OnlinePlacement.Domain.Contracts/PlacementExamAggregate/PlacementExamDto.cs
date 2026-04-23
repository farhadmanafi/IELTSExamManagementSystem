using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Domain.Contracts.PlacementExamAggregate
{
    public class PlacementExamDto
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ActivedDate { get; set; }
        public DateTime? DeActivedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
