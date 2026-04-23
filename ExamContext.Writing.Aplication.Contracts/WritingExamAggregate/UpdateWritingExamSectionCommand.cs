using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Writing.Aplication.Contracts.WritingExamAggregate
{
    public class UpdateWritingExamSectionCommand:Command
    {
        public Guid Id { get; set; }
        public Guid WritingExamId { get; set; }
        public string Title { get; set; }
        public string WritingTopic { get; set; }
        public int TimerMinuties { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
