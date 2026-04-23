using ExamContext.Listening.Domain.ListeningExamAggregate;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Persistence.ListeningExamAggregate.Mapping
{
    public class ListeningExamSectionMapping : EntityMappingBase<ListeningExamSection>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<ListeningExamSection> builder)
        {
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();

            builder.HasOne(x => x.CurrentListeningExam)
                   .WithMany(y => y.ListeningExamSectionList)
                   .HasForeignKey(a => a.ListeningExamId);
        }
    }
}
