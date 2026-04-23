using ExamContext.Reading.Domain.ReadingUserAnswerAggregate;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Persistence.ReadingUserAnswerAggregate.Mapping
{
    public class ReadingUserAnswerMapping : EntityMappingBase<ReadingUserAnswer>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<ReadingUserAnswer> builder)
        {
            builder.Property(p => p.ReadingExamId).IsRequired();
            builder.Property(p => p.IeltsExamParticipantId).IsRequired();
            builder.Property(p => p.QuestionId).IsRequired();
            builder.Property(p => p.AnswerId);
            builder.Property(p => p.AnswerText);
            builder.Property(p => p.CustomerId).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();
        }
    }
}
