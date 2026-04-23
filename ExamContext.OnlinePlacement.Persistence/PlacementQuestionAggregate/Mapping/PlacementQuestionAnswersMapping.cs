using ExamContext.OnlinePlacement.Domain.PlacementQuestionAggregate;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Persistence.PlacementQuestionAggregate.Mapping
{
    public class PlacementQuestionAnswersMapping : EntityMappingBase<PlacementQuestionAnswers>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<PlacementQuestionAnswers> builder)
        {
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Description);
            builder.Property(p => p.OrderNo).IsRequired();
            builder.Property(p => p.IsCorrect).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();

            builder.HasOne(e => e.PlacementQuestionCurrent).WithMany(c => c.PlacementQuestionAnswersList).HasForeignKey(a => a.PlacementQuestionId); //.OnDelete(DeleteBehavior.SetNull);

        }
    }
}
