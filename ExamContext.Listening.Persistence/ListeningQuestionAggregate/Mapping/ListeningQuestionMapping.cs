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
    public class ListeningQuestionMapping : EntityMappingBase<ListeningQuestion>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<ListeningQuestion> builder)
        {
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Description);
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();
            builder.Property(p => p.OrderNo).IsRequired();
            builder.Property(p => p.ListeningExamId).IsRequired();
            builder.Property(p => p.ListeningExamSectionId).IsRequired();
            builder.Property(p => p.ListeningExamQuestionBlockId).IsRequired();
            //builder.Property(p => p.ListeningQuestionTypeId).IsRequired();

            builder.HasOne(e => e.ListeningQuestionTypeCurrent).WithMany(c => c.ListeningQuestionList).HasForeignKey(a => a.ListeningQuestionTypeId); //.OnDelete(DeleteBehavior.SetNull);
        }
    }

}
