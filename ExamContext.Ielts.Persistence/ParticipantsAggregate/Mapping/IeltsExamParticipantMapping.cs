using ExamContext.Ielts.Domain.ParticipantsAggregate;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Persistence.ParticipantsAggregate.Mapping
{
    public class IeltsExamParticipantMapping : EntityMappingBase<IeltsExamParticipants>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<IeltsExamParticipants> builder)
        {
            builder.Property(p => p.CustomerId).IsRequired();
            builder.Property(p => p.IeltsExamId).IsRequired();
            builder.Property(p => p.IeltsExamPriceId).IsRequired();
            builder.Property(p => p.IeltsExamOrederNumber).IsRequired();
            builder.Property(p => p.RegisterDate).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();

            builder.HasOne(e => e.IeltsExamParticipantsStatusCurrent).WithMany(c => c.IeltsExamParticipantsList).HasForeignKey(a => a.IeltsExamParticipantsStatusId); //.OnDelete(DeleteBehavior.SetNull);


        }
    }
}
