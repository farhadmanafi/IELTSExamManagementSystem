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
    public class ReadingQuestionAnswersMapping : EntityMappingBase<ReadingQuestionAnswers>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<ReadingQuestionAnswers> builder)
        {

            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Description);
            builder.Property(p => p.OrderNo).IsRequired();
            builder.Property(p => p.IsCorrect).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();
            builder.Property(p => p.ReadingQuestionId).IsRequired();

            builder.HasOne(e => e.ReadingQuestionCurrent).WithMany(c => c.ReadingQuestionAnswersList).HasForeignKey(a => a.ReadingQuestionId); //.OnDelete(DeleteBehavior.SetNull);
        }
    }
}
