using System;
using System.Collections.Generic;

namespace IeltsProject.Presentation.Models
{
    public class IeltsReadingExamViewModel
    {
        public string ExamName { get; set; }
        public Guid ReadingExamId { get; set; }
        public Guid IeltsExamParticipantId { get; set; }
        public List<IeltsReadingQuestionViewModel> IeltsReadingQuestionViewModel { get; set; }
    }
    public class IeltsReadingQuestionViewModel
    {
        public Guid QuestionId { get; set; }
        public Guid QuestionTypeId { get; set; }
        public string QuestionTitle { get; set; }
        public Guid AnswerValue { get; set; }
        public string Value { get; set; }
        public List<IeltsReadingAnswerViewModel> IeltsReadingAnswerViewModel { get; set; }
        public Guid ReadingExamSectionId { get; set; }
        public int ReadingExamSectionOrderNo { get; set; }
        public string ReadingExamSectionTitle { get; set; }
        public string ReadingExamSectionReadingText { get; set; }
        public Guid ReadingExamQuestionBlockId { get; set; }
        public int ReadingExamQuestionBlockOrderNo { get; set; }
        public string ReadingExamQuestionBlockTitle { get; set; }
        public string ReadingExamQuestionBlockDescription { get; set; }
    }

    public class IeltsReadingAnswerViewModel
    {
        public Guid AnswerId { get; set; }
        public string AnswerTitle { get; set; }
        public string AnswerValue { get; set; }
        public bool Checked { get; set; }
    }
}
