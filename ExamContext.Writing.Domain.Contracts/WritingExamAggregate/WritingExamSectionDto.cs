using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Writing.Domain.Contracts.WritingExamAggregate
{
    public class WritingExamSectionDto
    {
        public Guid WritingExamId { get; set; }
        public string Title { get; set; }
        public string WritingTopic { get; set; }
        public int TimerMinuties { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
