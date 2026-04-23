using ExamContext.Speaking.Domain.SpeakingExamMeetingAggregate;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Speaking.Persistence.SpeakingExamMeetingAggregate.Mapping
{
    public class SpeakingExamMeetingReserveMapping : EntityMappingBase<SpeakingExamMeetingReserve>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<SpeakingExamMeetingReserve> builder)
        {
            builder.Property(p => p.CustomerId).IsRequired();
            builder.Property(p => p.IeltsExamParticipantId).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();

            builder.HasOne(x => x.currentSpeakingExamMeeting).WithMany(y => y.SpeakingExamMeetingReserveList)
                .HasForeignKey(a => a.SpeakingExamMeetingId);
        }
    }
}
