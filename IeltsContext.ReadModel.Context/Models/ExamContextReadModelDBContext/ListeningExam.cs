using System;
using System.Collections.Generic;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class ListeningExam
    {
        public ListeningExam()
        {
            ListeningExamSections = new HashSet<ListeningExamSection>();
        }

        public Guid Id { get; set; }
        public Guid IeltsExamId { get; set; }
        public string Title { get; set; }
        public string VoiceSource { get; set; }
        public int? TimerMinuties { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string Description { get; set; }
        public string PreVoiceSource { get; set; }

        public virtual ICollection<ListeningExamSection> ListeningExamSections { get; set; }
    }
}
