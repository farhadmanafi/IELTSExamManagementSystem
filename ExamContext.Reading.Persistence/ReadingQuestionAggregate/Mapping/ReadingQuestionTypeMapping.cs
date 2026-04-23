using ExamContext.Reading.Domain.ReadingQuestionAggregate;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Persistence.ReadingQuestionAggregate.Mapping
{
    public class ReadingQuestionTypeMapping : EntityMappingBase<ReadingQuestionType>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<ReadingQuestionType> builder)
        {
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.CodeName);
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();            
        }
    }
}
