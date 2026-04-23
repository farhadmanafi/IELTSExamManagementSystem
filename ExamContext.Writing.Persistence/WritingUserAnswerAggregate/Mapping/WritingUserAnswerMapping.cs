using ExamContext.Writing.Domain.WritingUserAnswerAggregate;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Writing.Persistence.WritingUserContextAggregate.Mapping
{
    public class WritingUserAnswertMapping : EntityMappingBase<WritingUserAnswer>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<WritingUserAnswer> builder)
        {
            builder.Property(p => p.WritingExamSectionId).IsRequired();
            builder.Property(p => p.IeltsExamParticipantId).IsRequired();
            builder.Property(p => p.AnswerText).IsRequired();
            builder.Property(p => p.CustomerId).IsRequired();
            builder.Property(p => p.RegisterDateTime).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();
        }
    }
}
