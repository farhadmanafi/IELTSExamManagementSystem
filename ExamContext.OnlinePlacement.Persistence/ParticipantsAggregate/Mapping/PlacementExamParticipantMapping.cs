using ExamContext.OnlinePlacement.Domain.ParticipantsAggregate;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Persistence.ParticipantsAggregate.Mapping
{
    public class PlacementExamParticipantMapping : EntityMappingBase<PlacementExamParticipants>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<PlacementExamParticipants> builder)
        {
            builder.Property(p => p.CustomerId).IsRequired();
            builder.Property(p => p.PlacementExamId).IsRequired();
            builder.Property(p => p.PlacementExamPriceId).IsRequired();
            builder.Property(p => p.PlacementExamOrederNumber).IsRequired();
            builder.Property(p => p.RegisterDate).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();

            builder.HasOne(e => e.PlacementExamParticipantsStatusCurrent).WithMany(c => c.PlacementExamParticipantsList).HasForeignKey(a => a.PlacementExamParticipantsStatusId); //.OnDelete(DeleteBehavior.SetNull);


        }
    }
}
