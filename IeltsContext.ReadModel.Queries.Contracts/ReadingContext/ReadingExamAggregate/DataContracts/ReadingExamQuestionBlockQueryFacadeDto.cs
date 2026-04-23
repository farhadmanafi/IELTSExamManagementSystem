using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingExamAggregate.DataContracts
{
    public class ReadingExamQuestionBlockQueryFacadeDto
    {
        public Guid Id { get; set; }
        public Guid ReadingExamSectionId { get; set; }
        public string Title { get; set; }
        public int OrderNo { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
