using System;
using System.Collections.Generic;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class UserResualt
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid ParticipantsId { get; set; }
        public float? FinalScore { get; set; }
        public float? ListeningScore { get; set; }
        public float? ReadingScore { get; set; }
        public float? SpeakingScore { get; set; }
        public float? WritingScore { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Guid IeltsResualtLevelId { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid CustomerId { get; set; }

        public virtual IeltsResualtLevel IeltsResualtLevel { get; set; }
    }
}
