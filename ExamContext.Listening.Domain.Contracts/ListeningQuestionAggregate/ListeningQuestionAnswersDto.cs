using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Domain.Contracts.ListeningQuestionAggregate
{
    public class ListeningQuestionAnswersDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int OrderNo { get; set; }
        public bool IsCorrect { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public Guid ListeningQuestionId { get; set; }
    }
}
