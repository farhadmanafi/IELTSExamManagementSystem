using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningQuestionAggregate.DataContracts
{
    public class ListeningQuestionQueryFacadeDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public float Score { get; set; }
        public Guid ListeningExamId { get; set; }
        public Guid ListeningExamSectionId { get; set; }
        public int ListeningExamSectionOrderNo { get; set; }
        public string ListeningExamSectionTitle { get; set; }
        public Guid ListeningExamQuestionBlockId { get; set; }
        public int ListeningExamQuestionBlockOrderNo { get; set; }
        public string ListeningExamQuestionBlockTitle { get; set; }
        public string ListeningExamQuestionBlockDescription { get; set; }
        public Guid ListeningQuestionTypeId { get; set; }
        public string ListeningQuestionTypeTitle { get; set; }
        public string ListeningQuestionTypeCodeName { get; set; }
        public List<ListeningQuestionAnswersQueryFacadeDto> ListeningQuestionAnswers { get; set; }
    }
}
