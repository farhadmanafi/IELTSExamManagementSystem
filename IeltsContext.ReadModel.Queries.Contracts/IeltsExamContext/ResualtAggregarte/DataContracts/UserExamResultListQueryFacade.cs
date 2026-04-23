using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ResualtAggregarte.DataContracts
{
    public class UserExamResultListQueryFacade
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Title { get; set; }
        public float? ListeningScore { get; set; }
        public float? ReadingScore { get; set; }
        public float? SpeakingScore { get; set; }
        public float? WritingScore { get; set; }

    }
}
