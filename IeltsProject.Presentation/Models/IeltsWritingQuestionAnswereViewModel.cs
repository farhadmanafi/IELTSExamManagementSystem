using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace IeltsProject.Presentation.Models
{
    public class IeltsWritingExamViewModel
    {
        public string ExamName { get; set; }
        public Guid WritingExamId { get; set; }
        public Guid IeltsExamParticipantId { get; set; }
        public List<IeltsWritingSectionViewModel> IeltsWritingSectionViewModel { get; set; }
    }
    public class IeltsWritingSectionViewModel
    {
        public Guid SectionId { get; set; }
        public string SectionTitle { get; set; }
        public string WritingTopic { get; set; }
        public string Value { get; set; }
        public int? TimerMinuties { get; set; }
        public IFormFile? File { get; set; }
    }
}
