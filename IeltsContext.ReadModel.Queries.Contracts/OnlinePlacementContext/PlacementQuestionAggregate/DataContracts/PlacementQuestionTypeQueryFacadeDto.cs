using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementQuestionAggregate.DataContracts
{
    public class PlacementQuestionTypeQueryFacadeDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string CodeName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
