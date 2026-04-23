using ExamContext.Reading.Domain.ReadingExamAggregate;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Persistence.ReadingExamAggregate.Mapping
{
    public class ReadingExamMapping : EntityMappingBase<ReadingExam>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<ReadingExam> builder)
        {
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Description);
            builder.Property(p => p.IeltsExamId).IsRequired();
            builder.Property(p => p.TimerMinuties);
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();
        }
    }
}
