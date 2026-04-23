using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Aplication.Contracts.ReadingExamAggregate
{
    public class AddReadingExamSectionCommand:Command
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
