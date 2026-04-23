using ExamContext.Speaking.Domain.SpeakingExamAggregate;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Speaking.Persistence.SpeakingExamAggregate.Mapping
{
    public class SpeakingExamMapping : EntityMappingBase<SpeakingExam>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<SpeakingExam> builder)
        {
            builder.Property(p => p.IeltsExamId).IsRequired();
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Description);
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();
        }
    }
}