using ExamContext.Reading.Domain.ReadingQuestionAggregate;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Persistence.ReadingQuestionAggregate.Mapping
{
    public class ReadingQuestionMapping : EntityMappingBase<ReadingQuestion>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<ReadingQuestion> builder)
        {
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Description);
            builder.Property(p => p.OrderNo).IsRequired();
            builder.Property(p => p.Score).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();
            //builder.Property(p => p.ReadingQuestionTypeId).IsRequired();
            builder.Property(p => p.ReadingExamSectionId).IsRequired();
            builder.Property(p => p.ReadingExamQuestionBlockId).IsRequired();
            builder.Property(p => p.ReadingExamId).IsRequired();

            builder.HasOne(e => e.ReadingQuestionTypeCurrent).WithMany(c => c.ReadingQuestionList).HasForeignKey(a => a.ReadingQuestionTypeId); //.OnDelete(DeleteBehavior.SetNull);
        }
    }
}
