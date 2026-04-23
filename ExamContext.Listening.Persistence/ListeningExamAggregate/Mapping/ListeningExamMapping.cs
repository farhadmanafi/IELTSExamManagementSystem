using ExamContext.Listening.Domain.ListeningExamAggregate;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Persistence.ListeningExamAggregate.Mapping
{
    public class ListeningExamMapping : EntityMappingBase<ListeningExam>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<ListeningExam> builder)
        {
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Description);
            builder.Property(p => p.IeltsExamId).IsRequired();
            builder.Property(p => p.PreVoiceSource);
            builder.Property(p => p.VoiceSource);
            builder.Property(p => p.TimerMinuties);
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();
        }
    }
}
