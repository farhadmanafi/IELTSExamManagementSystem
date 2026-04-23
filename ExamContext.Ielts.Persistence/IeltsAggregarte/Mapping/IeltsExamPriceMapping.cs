using ExamContext.Ielts.Domain.IeltsAggregarte;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Persistence.IeltsAggregarte.Mapping
{
    public class IeltsExamPriceMapping : EntityMappingBase<IeltsExamPrice>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<IeltsExamPrice> builder)
        {
            builder.Property(p => p.PriceAmount).IsRequired();
            builder.Property(p => p.DiscontentAmount);
            builder.Property(p => p.ActivedDate);
            builder.Property(p => p.DeactivedDate);
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();

            builder.HasOne(e => e.IeltsExamCurrent).WithMany(c => c.IeltsExamPriceList).HasForeignKey(a => a.IeltsExamId); //.OnDelete(DeleteBehavior.SetNull);
        }
    }
}
