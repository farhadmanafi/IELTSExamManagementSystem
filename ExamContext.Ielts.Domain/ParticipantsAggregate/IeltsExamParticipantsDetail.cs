using ExamContext.Ielts.Domain.Contracts.ParticipantsAggregate;
using Framework.Core.Domain;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Domain.ParticipantsAggregate
{
    public class IeltsExamParticipantsDetail : EntityBase, IAggregateRoot<IeltsExamParticipantsDetail>
    {
        public IeltsExamParticipantsDetail()
        {

        }
        public IeltsExamParticipantsDetail(IeltsExamParticipantsDetailDto dto)
        {
            ListeningExamId = dto.ListeningExamId;
            ListeningExamIsGive = dto.ListeningExamIsGive;
            ListeningExamStartDateTime = dto.ListeningExamStartDateTime;
            ListeningExamEndDateTime = dto.ListeningExamEndDateTime;
            ListeningExamRegisterDateTime = dto.ListeningExamRegisterDateTime;

            ReadingExamId = dto.ReadingExamId;
            ReadingExamIsGive = dto.ReadingExamIsGive;
            ReadingExamStartDateTime = dto.ReadingExamStartDateTime;
            ReadingExamEndDateTime = dto.ReadingExamEndDateTime;
            ReadingExamRegisterDateTime = dto.ReadingExamRegisterDateTime;

            WritingExamId = dto.WritingExamId;
            WritingExamIsGive = dto.WritingExamIsGive;
            WritingExamStartDateTime = dto.WritingExamStartDateTime;
            WritingExamEndDateTime = dto.WritingExamEndDateTime;
            WritingExamRegisterDateTime = dto.WritingExamRegisterDateTime;

            SpeakingExamId = dto.SpeakingExamId;
            SpeakingExamIsSetSession = dto.SpeakingExamIsSetSession;

            IeltsExamParticipantsId = dto.IeltsExamParticipantsId;
        }

        public Guid? ListeningExamId { get; set; }
        public bool? ListeningExamIsGive { get; set; }
        public DateTime? ListeningExamStartDateTime { get; set; }
        public DateTime? ListeningExamEndDateTime { get; set; }
        public DateTime? ListeningExamRegisterDateTime { get; set; }

        public Guid? ReadingExamId { get; set; }
        public bool? ReadingExamIsGive { get; set; }
        public DateTime? ReadingExamStartDateTime { get; set; }
        public DateTime? ReadingExamEndDateTime { get; set; }
        public DateTime? ReadingExamRegisterDateTime { get; set; }

        public Guid? WritingExamId { get; set; }
        public bool? WritingExamIsGive { get; set; }
        public DateTime? WritingExamStartDateTime { get; set; }
        public DateTime? WritingExamEndDateTime { get; set; }
        public DateTime? WritingExamRegisterDateTime { get; set; }

        public Guid? SpeakingExamId { get; set; }
        public bool? SpeakingExamIsSetSession { get; set; }

        public Guid IeltsExamParticipantsId { get; set; }
        [ForeignKey("IeltsExamParticipantsId")]
        public IeltsExamParticipants IeltsExamParticipantsCurrent { get; set; }

        public IEnumerable<Expression<Func<IeltsExamParticipantsDetail, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}