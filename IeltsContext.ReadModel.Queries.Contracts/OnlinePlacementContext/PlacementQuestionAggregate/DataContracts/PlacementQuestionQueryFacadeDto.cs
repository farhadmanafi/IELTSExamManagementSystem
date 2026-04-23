using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementQuestionAggregate.DataContracts
{
    public class PlacementQuestionQueryFacadeDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CustomerId { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Guid PlacementExamtId { get; set; }
        public Guid PlacementQuestionTypeId { get; set; }
        public string PlacementQuestionTypeTitle { get; set; }
        public string PlacementQuestionTypeCodeName { get; set; }
        public List<PlacementQuestionAnswersQueryFacadeDto> PlacementQuestionAnswers { get; set; }
    }
}
