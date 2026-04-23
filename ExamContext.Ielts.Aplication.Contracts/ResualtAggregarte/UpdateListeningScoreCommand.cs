using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Aplication.Contracts.ResualtAggregarte
{
    public class UpdateListeningScoreCommand:Command
    {
        public Guid CustomerId { get; set; }
        public Guid IeltsExamParticipantsId { get; set; }
        public float? FinalScore { get; set; }
        public float ListeningScore { get; set; }
    }
}
