using ExamContext.OnlinePlacement.Domain.PlacementUserScoreAggregate;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Persistence.PlacementUserScoreAggregate.Mapping
{
    public class PlacementUserScoreMapping : EntityMappingBase<PlacementUserScore>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<PlacementUserScore> builder)
        {
            builder.Property(p => p.PlacementExamId).IsRequired();
            builder.Property(p => p.CustomerId).IsRequired();
            builder.Property(p => p.ExamDate).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();

            builder.HasOne(e => e.LevelScoreCurrent).WithMany(c => c.PlacementUserScoreList).HasForeignKey(a => a.LevelScoreId); //.OnDelete(DeleteBehavior.SetNull);

        }
    }
}
