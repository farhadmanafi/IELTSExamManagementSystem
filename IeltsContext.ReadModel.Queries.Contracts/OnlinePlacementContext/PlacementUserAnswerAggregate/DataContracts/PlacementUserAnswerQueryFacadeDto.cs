using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementUserAnswerAggregate.DataContracts
{
    public class PlacementUserAnswerQueryFacadeDto
    {
        public Guid Id { get; set; }
        public Guid IeltsExamId { get; set; }
        public Guid PlacementUserScoreId { get; set; }
        public Guid QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public Guid? AnswerId { get; set; }
        public string AnswerTitle { get; set; }
        public string AnswerText { get; set; }
        public Guid CustomerId { get; set; }
        public bool? IsCorrectAnswer { get; set; }
    }
}
