using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Domain.Contracts.ReadingExamAggregate
{
    public class ReadingExamQuestionBlockDto
    {
        public Guid ReadingExamSectionId { get; set; }
        public string Title { get; set; }
        public int OrderNo { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
