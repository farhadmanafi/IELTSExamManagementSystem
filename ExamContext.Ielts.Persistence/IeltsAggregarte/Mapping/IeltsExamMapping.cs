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
    public class IeltsExamMapping : EntityMappingBase<IeltsExam>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<IeltsExam> builder)
        {
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.ActivedDate);
            builder.Property(p => p.DeactivedDate);
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();

        }
    }
}
