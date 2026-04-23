using ExamContext.Writing.Domain.WritingExamAggregate;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Writing.Persistence.WritingExamAggregate.Mapping
{
    public class WritingExamSectionMapping : EntityMappingBase<WritingExamSection>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<WritingExamSection> builder)
        {
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.TimerMinuties);
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();

            builder.HasOne(x => x.CurrentWritingExam)
                   .WithMany(y => y.WritingExamSectionList)
                   .HasForeignKey(a => a.WritingExamId);
        }
    }
}
