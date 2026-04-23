using System;
using System.Collections.Generic;

namespace IeltsProject.Presentation.Models
{
    public class IeltsSpeakingQuestionAnswereViewModel
    {
        public string ExamName { get; set; }
        public Guid IeltsExamId { get; set; }
        public Guid IeltsExamParticipantId { get; set; }
        public Guid IeltsSpeakingId { get; set; }
        public Guid MeetingId { get; set; }

    }
}
