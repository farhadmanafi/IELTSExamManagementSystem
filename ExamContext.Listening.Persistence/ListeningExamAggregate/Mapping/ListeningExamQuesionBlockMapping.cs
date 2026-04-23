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
    public class ListeningExamQuesionBlockMapping : EntityMappingBase<ListeningExamQuestionBlock>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<ListeningExamQuestionBlock> builder)
        {            
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.OrderNo).IsRequired();
            builder.Property(p => p.Description);
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();

            builder.HasOne(x => x.CurrentListeningExamSection)
                .WithMany(y => y.ListeningExamQuestionBlockList)
                   .HasForeignKey(a => a.ListeningExamSectionId);
        }
    }
}
