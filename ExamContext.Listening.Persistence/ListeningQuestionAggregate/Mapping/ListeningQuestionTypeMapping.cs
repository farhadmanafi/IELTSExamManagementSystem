using ExamContext.Listening.Domain.ListeningQuestionAggregate;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Persistence.ListeningQuestionAggregate.Mapping
{
    public class ListeningQuestionTypeMapping : EntityMappingBase<ListeningQuestionType>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<ListeningQuestionType> builder)
        {
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.CodeName);
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();
        }
    }
}
