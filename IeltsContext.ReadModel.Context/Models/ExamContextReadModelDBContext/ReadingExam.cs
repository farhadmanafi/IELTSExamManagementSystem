using System;
using System.Collections.Generic;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class ReadingExam
    {
        public ReadingExam()
        {
            ReadingExamSections = new HashSet<ReadingExamSection>();
        }

        public Guid Id { get; set; }
        public Guid IeltsExamId { get; set; }
        public string Title { get; set; }
        public int? TimerMinuties { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ReadingExamSection> ReadingExamSections { get; set; }
    }
}
