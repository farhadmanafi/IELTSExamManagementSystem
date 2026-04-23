using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Domain.Contracts.ListeningExamAggregate
{
    public class ListeningExamSectionDto
    {
        public string Title { get; set; }
        public Guid ListeningExamId { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
