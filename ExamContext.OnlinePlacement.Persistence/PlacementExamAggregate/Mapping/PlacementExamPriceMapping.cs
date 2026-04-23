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
    internal class PlacementExamPriceMapping : EntityMappingBase<PlacementExamPrice>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<PlacementExamPrice> builder)
        {
            builder.Property(p => p.PriceAmount).IsRequired();
            builder.Property(p => p.DiscontentAmount);
            builder.Property(p => p.ActivedDate);
            builder.Property(p => p.DeactivedDate);
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();

            builder.HasOne(e => e.PlacementExamCurrent).WithMany(c => c.PlacementExamPriceList).HasForeignKey(a => a.PlacementExamId); //.OnDelete(DeleteBehavior.SetNull);
        }
    }
}
