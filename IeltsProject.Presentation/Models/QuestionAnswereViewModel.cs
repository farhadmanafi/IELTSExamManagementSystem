using System;
using System.Collections.Generic;

namespace IeltsProject.Presentation.Models
{
    public class ExamViewModel
    {
        public string ExamName { get; set; }
        public Guid ExamId { get; set; }
        public List<QuestionViewModel> QuestionViewModel { get; set; }
    }
    public class QuestionViewModel
    {
        public Guid QuestionId { get; set; }
        public Guid QuestionTypeId { get; set; }
        public string QuestionTitle { get; set; }
        public Guid AnswerValue { get; set; }
        public string Value { get; set; }
        public List<AnswerViewModel> AnswerViewModel { get; set; }
    }

    public class AnswerViewModel
    {
        public Guid AnswerId { get; set; }
        public string AnswerTitle { get; set; }
        public string AnswerValue { get; set; }
        public bool Checked { get; set; }
    }
}
