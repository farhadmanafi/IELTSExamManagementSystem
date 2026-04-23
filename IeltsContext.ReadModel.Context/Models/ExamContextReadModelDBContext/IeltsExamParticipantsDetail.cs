using System;
using System.Collections.Generic;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class IeltsExamParticipantsDetail
    {
        public Guid Id { get; set; }
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
        public DateTime TimeStamp { get; set; }

        public virtual IeltsExamParticipant IeltsExamParticipants { get; set; }
    }
}
