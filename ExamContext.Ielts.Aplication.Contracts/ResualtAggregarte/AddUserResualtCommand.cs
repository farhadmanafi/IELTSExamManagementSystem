using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Aplication.Contracts.ResualtAggregarte
{
    public class AddUserResualtCommand:Command
    {
        public Guid? UserId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ParticipantsId { get; set; }
        public float? FinalScore { get; set; }
        public float? ListeningScore { get; set; }
        public float? ReadingScore { get; set; }
        public float? SpeakingScore { get; set; }
        public float? WritingScore { get; set; }
        public Guid IeltsResualtLevelId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
