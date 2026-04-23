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
    public class LevelScoreMapping : EntityMappingBase<LevelScore>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<LevelScore> builder)
        {
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.LevelName).IsRequired();
            builder.Property(p => p.MinScore).IsRequired();
            builder.Property(p => p.MaxScore).IsRequired();
            builder.Property(p => p.OrderNo).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();
        }
    }
}
