using ExamContext.Ielts.Domain.ResualtAggregarte;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Persistence.ResualtAggregarte.Mapping
{
    public class IeltsResualtLevelMapping : EntityMappingBase<IeltsResualtLevel>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<IeltsResualtLevel> builder)
        {
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.OrderNo).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();
        }
    }
}
