using ExamContext.Ielts.Domain.ResualtAggregarte;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Persistence.ResualtAggregarte.Mapping
{
    public class UserResualtMapping : EntityMappingBase<UserResualt>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<UserResualt> builder)
        {
            builder.Property(p => p.UserId);
            builder.Property(p => p.CustomerId).IsRequired();
            builder.Property(p => p.ParticipantsId).IsRequired();
            builder.Property(p => p.FinalScore);
            builder.Property(p => p.ListeningScore);
            builder.Property(p => p.ReadingScore);
            builder.Property(p => p.SpeakingScore);
            builder.Property(p => p.WritingScore);
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();

            builder.HasOne(e => e.IeltsResualtLevelCurrent).WithMany(c => c.UserResualtList).HasForeignKey(a => a.IeltsResualtLevelId); //.OnDelete(DeleteBehavior.SetNull);
        }
    }
}
