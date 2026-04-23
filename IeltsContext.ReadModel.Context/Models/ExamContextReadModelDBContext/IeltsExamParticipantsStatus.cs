using System;
using System.Collections.Generic;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class IeltsExamParticipantsStatus
    {
        public IeltsExamParticipantsStatus()
        {
            IeltsExamParticipants = new HashSet<IeltsExamParticipant>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual ICollection<IeltsExamParticipant> IeltsExamParticipants { get; set; }
    }
}
