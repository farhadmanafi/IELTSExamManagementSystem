using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Domain.Contracts.ReadingExamAggregate
{
    public class ReadingExamSectionDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReadingText { get; set; }
        public int OrderNo { get; set; }
        public Guid ReadingExamId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
