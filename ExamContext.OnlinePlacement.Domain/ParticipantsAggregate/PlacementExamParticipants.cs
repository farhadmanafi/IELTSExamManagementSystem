using ExamContext.OnlinePlacement.Domain.Contracts.ParticipantsAggregate;
using ExamContext.OnlinePlacement.Domain.ParticipantsAggregate.Event;
using Framework.Core.Domain;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Domain.ParticipantsAggregate
{
    public class PlacementExamParticipants : EntityBase,IAggregateRoot<PlacementExamParticipants>
    {
        public PlacementExamParticipants()
        {

        }
        public PlacementExamParticipants(PlacementExamParticipantsDto dto)
        {
            CustomerId = dto.CustomerId;
            PlacementExamId = dto.PlacementExamId;
            PlacementExamPriceId = dto.PlacementExamPriceId;
            PlacementExamOrederNumber = dto.PlacementExamOrederNumber;
            RegisterDate = dto.RegisterDate;
            PlacementExamParticipantsStatusId = dto.PlacementExamParticipantsStatusId;
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;

            EventBus.Publish(new AddPlacementExamParticipantsEvent(Id));
        }

        public Guid CustomerId { get; set; }
        public Guid PlacementExamId { get; set; }
        public Guid PlacementExamPriceId { get; set; }
        public int PlacementExamOrederNumber { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public Guid PlacementExamParticipantsStatusId { get; set; }
        [ForeignKey("PlacementExamParticipantsStatusId")]
        public PlacementExamParticipantsStatus PlacementExamParticipantsStatusCurrent { get; set; }

        public IEnumerable<System.Linq.Expressions.Expression<Func<PlacementExamParticipants, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}