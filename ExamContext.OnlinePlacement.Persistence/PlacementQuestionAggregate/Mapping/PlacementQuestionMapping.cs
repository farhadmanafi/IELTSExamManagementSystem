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
    public class PlacementQuestionMapping : EntityMappingBase<PlacementQuestion>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<PlacementQuestion> builder)
        {
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.PlacementExamtId).IsRequired();
            builder.Property(p => p.Description);
            builder.Property(p => p.OrderNo).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();

            builder.HasOne(e => e.PlacementQuestionTypeCurrent).WithMany(c => c.PlacementQuestionList).HasForeignKey(a => a.PlacementQuestionTypeId); //.OnDelete(DeleteBehavior.SetNull);

        }
    }
}
