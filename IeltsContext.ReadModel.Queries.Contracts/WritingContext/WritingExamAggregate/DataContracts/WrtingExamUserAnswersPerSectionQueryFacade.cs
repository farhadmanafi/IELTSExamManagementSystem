using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.WritingContext.WritingExamAggregate.DataContracts
{
    public class WrtingExamUserAnswersPerSectionQueryFacade
    {
        public Guid IeltsExamId { get; set; }
        public Guid WritingExamId { get; set; }
        public Guid WritingExamSectionId { get; set; }
        public string WritingTopic { get; set; }
        public string SectionTitle { get; set; }

        public string AnswerText { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
    }
}
