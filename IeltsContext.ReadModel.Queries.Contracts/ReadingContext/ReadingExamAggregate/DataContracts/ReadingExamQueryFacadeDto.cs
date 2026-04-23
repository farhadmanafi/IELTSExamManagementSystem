using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingExamAggregate.DataContracts
{
    public class ReadingExamQueryFacadeDto
    {
        public Guid Id { get; set; }
        public Guid IeltsExamId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? TimerMinuties { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
