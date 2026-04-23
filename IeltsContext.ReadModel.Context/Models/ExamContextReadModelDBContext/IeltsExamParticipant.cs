using System;
using System.Collections.Generic;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class IeltsExamParticipant
    {
        public IeltsExamParticipant()
        {
            IeltsExamParticipantsDetails = new HashSet<IeltsExamParticipantsDetail>();
        }

        public Guid Id { get; set; }
        public DateTime RegisterDate { get; set; }
        public Guid IeltsExamId { get; set; }
        public DateTime TimeStamp { get; set; }
        public int IeltsExamOrederNumber { get; set; }
        public Guid IeltsExamPriceId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid CustomerId { get; set; }
        public Guid IeltsExamParticipantsStatusId { get; set; }

        public virtual IeltsExamParticipantsStatus IeltsExamParticipantsStatus { get; set; }
        public virtual ICollection<IeltsExamParticipantsDetail> IeltsExamParticipantsDetails { get; set; }
    }
}
