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
    public class ListeningQuestionAnswersMapping : EntityMappingBase<ListeningQuestionAnswers>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<ListeningQuestionAnswers> builder)
        {
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Description);
            builder.Property(p => p.OrderNo).IsRequired();
            builder.Property(p => p.IsCorrect).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();
            //builder.Property(p => p.ListeningQuestionId).IsRequired();

            builder.HasOne(e => e.ListeningQuestionCurrent).WithMany(c => c.ListeningQuestionAnswersList).HasForeignKey(a => a.ListeningQuestionId); //.OnDelete(DeleteBehavior.SetNull);
        }
    }
}
