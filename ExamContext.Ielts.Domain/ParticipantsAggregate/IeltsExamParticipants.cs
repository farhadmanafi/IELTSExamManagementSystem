using ExamContext.Ielts.Domain.Contracts.ParticipantsAggregate;
using ExamContext.Ielts.Domain.ParticipantsAggregate.Event;
using Framework.Core.Domain;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Domain.ParticipantsAggregate
{
    public class IeltsExamParticipants : EntityBase,IAggregateRoot<IeltsExamParticipants>
    {
        public IeltsExamParticipants()
        {

        }
        public IeltsExamParticipants(IeltsExamParticipantsDto dto)
        {
            CustomerId = dto.CustomerId;
            IeltsExamId = dto.IeltsExamId;
            IeltsExamPriceId = dto.IeltsExamPriceId;
            IeltsExamOrederNumber = dto.IeltsExamOrederNumber;
            RegisterDate = dto.RegisterDate;
            IeltsExamParticipantsStatusId = dto.IeltsExamParticipantsStatusId;
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
            IeltsExamParticipantsDetailList = new List<IeltsExamParticipantsDetail>();

            EventBus.Publish(new AddIeltsExamParticipantsEvent(Id));
        }

        public Guid CustomerId { get; set; }
        public Guid IeltsExamId { get; set; }
        public Guid IeltsExamPriceId { get; set; }
        public int IeltsExamOrederNumber { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public Guid IeltsExamParticipantsStatusId { get; set; }
        [ForeignKey("IeltsExamParticipantsStatusId")]
        public IeltsExamParticipantsStatus IeltsExamParticipantsStatusCurrent { get; set; }

        public ICollection<IeltsExamParticipantsDetail> IeltsExamParticipantsDetailList { get; set; }
        
        public void AddIeltsExamParticipantsDetailDto(IeltsExamParticipantsDetail ieltsExamParticipantsDetail)
        {
            IeltsExamParticipantsDetailList.Add(ieltsExamParticipantsDetail);
        }

        public IEnumerable<System.Linq.Expressions.Expression<Func<IeltsExamParticipants, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}