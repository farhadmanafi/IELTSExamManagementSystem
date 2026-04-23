using System;
using System.Collections.Generic;

namespace IeltsProject.Presentation.Models
{
    public class IeltsListeningExamViewModel
    {
        public string ExamName { get; set; }
        public Guid ListeningExamId { get; set; }
        public Guid IeltsExamParticipantId { get; set; }
        public string PreVoiceSource { get; set; }
        public string VoiceSource { get; set; }
        public List<IeltsListeningQuestionViewModel> IeltsListeningQuestionViewModel { get; set; }
    }
    public class IeltsListeningQuestionViewModel
    {
        public Guid QuestionId { get; set; }
        public Guid QuestionTypeId { get; set; }
        public string QuestionTitle { get; set; }
        public Guid AnswerValue { get; set; }
        public string Value { get; set; }
        public List<IeltsListeningAnswerViewModel> IeltsListeningAnswerViewModel { get; set; }
        public Guid ListeningExamSectionId { get; set; }
        public int ListeningExamSectionOrderNo { get; set; }
        public string ListeningExamSectionTitle { get; set; }
        public Guid ListeningExamQuestionBlockId { get; set; }
        public int ListeningExamQuestionBlockOrderNo { get; set; }
        public string ListeningExamQuestionBlockTitle { get; set; }
        public string ListeningExamQuestionBlockDescription { get; set; }
    }

    public class IeltsListeningAnswerViewModel
    {
        public Guid AnswerId { get; set; }
        public string AnswerTitle { get; set; }
        public string AnswerValue { get; set; }
        public bool Checked { get; set; }
    }
}
