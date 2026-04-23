using ExamContext.Listening.Domain.ListeningUserAnswerAggregate;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Persistence.ListeningUserAnswerAggregate.Mapping
{
    public class ListeningUserAnswerMapping : EntityMappingBase<ListeningUserAnswer>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<ListeningUserAnswer> builder)
        {
            builder.Property(p => p.ListeningExamId).IsRequired();
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
