using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Domain.Contracts.ListeningQuestionAggregate
{
    public class ListeningQuestionDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public float Score { get; set; }
        public Guid ListeningExamId { get; set; }
        public Guid ListeningQuestionTypeId { get; set; }
        public Guid ListeningExamSectionId { get; set; }
        public Guid ListeningExamQuestionBlockId { get; set; }
    }
}
