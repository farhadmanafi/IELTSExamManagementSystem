using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingQuestionAggregate.DataContracts
{
    public class ReadingQuestionQueryFacadeDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public float Score { get; set; }
        public Guid ReadingExamId { get; set; }
        public Guid ReadingExamSectionId { get; set; }
        public int ReadingExamSectionOrderNo { get; set; }
        public string ReadingExamSectionTitle { get; set; }
        public string ReadingExamSectionReadingText { get; set; }
        public Guid ReadingExamQuestionBlockId { get; set; }
        public int ReadingExamQuestionBlockOrderNo { get; set; }
        public string ReadingExamQuestionBlockTitle { get; set; }
        public string ReadingExamQuestionBlockDescription { get; set; }
        public Guid ReadingQuestionTypeId { get; set; }
        public string ReadingQuestionTypeTitle { get; set; }
        public string ReadingQuestionTypeCodeName { get; set; }
        public List<ReadingQuestionAnswersQueryFacadeDto> ReadingQuestionAnswers { get; set; }
    }
}
