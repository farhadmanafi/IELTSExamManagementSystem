using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Speaking.Domain.Contracts.SpeakingExamAggregate
{
    public class SpeakingExamDto
    {
        public Guid IeltsExamId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
