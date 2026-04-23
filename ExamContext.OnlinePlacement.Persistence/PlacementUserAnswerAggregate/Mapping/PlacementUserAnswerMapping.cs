using ExamContext.OnlinePlacement.Domain.PlacementUserAnswerAggregate;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Persistence.PlacementUserAnswerAggregate.Mapping
{
    public class PlacementUserAnswerMapping : EntityMappingBase<PlacementUserAnswer>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<PlacementUserAnswer> builder)
        {
            builder.Property(p => p.IeltsExamId).IsRequired();
            builder.Property(p => p.PlacementUserScoreId).IsRequired();
            builder.Property(p => p.QuestionId).IsRequired();
            builder.Property(p => p.AnswerId);
            builder.Property(p => p.AnswerText);
            builder.Property(p => p.CustomerId).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();
        }
    }
}
