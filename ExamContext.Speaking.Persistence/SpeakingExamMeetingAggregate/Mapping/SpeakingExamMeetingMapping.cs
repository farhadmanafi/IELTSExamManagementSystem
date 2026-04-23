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
    public class SpeakingExamMeetingMapping : EntityMappingBase<SpeakingExamMeeting>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<SpeakingExamMeeting> builder)
        {
            builder.Property(p => p.SpeakingExamId).IsRequired();
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.MeetingDate).IsRequired();
            builder.Property(p => p.MeetingStartTime).IsRequired();
            builder.Property(p => p.MeetingEndTime).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();
        }
    }
}
