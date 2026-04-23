using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Aplication.Contracts.ReadingQuestionAggregate
{
    public class AddReadingQuestionCommand:Command
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public float Score { get; set; }
        public Guid ReadingQuestionTypeId { get; set; }
        public Guid ReadingQuestionTReadingExamIdypeId { get; set; }
        public Guid ReadingExamId { get; set; }
        public Guid ReadingExamSectionId { get; set; }
        public Guid ReadingExamQuestionBlockId { get; set; }
        public string ReadingQuestionTypeTitle { get; set; }
    }
}
