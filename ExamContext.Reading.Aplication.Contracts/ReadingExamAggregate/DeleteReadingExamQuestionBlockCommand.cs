using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Aplication.Contracts.ReadingExamAggregate
{
    public class DeleteReadingExamQuestionBlockCommand:Command
    {
        public Guid Id { get; set; }
        public Guid ReadingExamId { get; set; }
        public string Title { get; set; }
        public int StartQuestionNumber { get; set; }
        public int EndQuestionNumber { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
