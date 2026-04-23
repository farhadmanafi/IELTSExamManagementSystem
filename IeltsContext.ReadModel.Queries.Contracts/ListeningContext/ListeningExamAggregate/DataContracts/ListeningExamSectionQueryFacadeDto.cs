using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningExamAggregate.DataContracts
{
    public class ListeningExamSectionQueryFacadeDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Guid ListeningExamId { get; set; }
    }
}
