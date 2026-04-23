using ExamContext.Ielts.Domain.Contracts.ResualtAggregarte;
using Framework.Core.Domain;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Domain.ResualtAggregarte
{
    public class UserResualt : EntityBase, IAggregateRoot<UserResualt>
    {
        public UserResualt()
        {

        }
        public UserResualt(UserResualtDto dto)
        {
            UserId = dto.UserId;
            CustomerId = dto.CustomerId;
            ParticipantsId = dto.ParticipantsId;
            FinalScore = dto.FinalScore;
            ListeningScore = dto.ListeningScore;
            ReadingScore = dto.ReadingScore;
            SpeakingScore = dto.SpeakingScore;
            WritingScore = dto.WritingScore;
            IeltsResualtLevelId = dto.IeltsResualtLevelId;
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
        }
        public Guid? UserId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ParticipantsId { get; set; }
        public float? FinalScore { get; set; }
        public float? ListeningScore { get; set; }
        public float? ReadingScore { get; set; }
        public float? SpeakingScore { get; set; }
        public float? WritingScore { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Guid IeltsResualtLevelId { get; set; }
        [ForeignKey("IeltsResualtLevelId")]
        public IeltsResualtLevel IeltsResualtLevelCurrent { get; set; }

        public IEnumerable<Expression<Func<UserResualt, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}
