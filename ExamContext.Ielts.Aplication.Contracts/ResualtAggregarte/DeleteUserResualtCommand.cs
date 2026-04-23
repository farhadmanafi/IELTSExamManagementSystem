using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Aplication.Contracts.ResualtAggregarte
{
    public class DeleteUserResualtCommand:Command
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid IeltsExamId { get; set; }
        public float FinalScore { get; set; }
        public float ListeningScore { get; set; }
        public float ReadingScore { get; set; }
        public float SpeakingScore { get; set; }
        public float WritingScore { get; set; }
        public Guid IeltsResualtLevelId { get; set; }
    }
}
