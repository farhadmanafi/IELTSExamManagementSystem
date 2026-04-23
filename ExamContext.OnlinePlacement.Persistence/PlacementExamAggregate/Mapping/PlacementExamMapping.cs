using ExamContext.OnlinePlacement.Domain.PlacementExamAggregate;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Persistence.PlacementExamAggregate.Mapping
{
    public class PlacementExamMapping : EntityMappingBase<PlacementExam>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<PlacementExam> builder)
        {
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Description);
            builder.Property(p => p.ActivedDate);
            builder.Property(p => p.DeActivedDate);
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();
        }
    }
}
