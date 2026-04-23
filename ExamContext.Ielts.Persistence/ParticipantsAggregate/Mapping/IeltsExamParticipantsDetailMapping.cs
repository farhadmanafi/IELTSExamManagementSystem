using ExamContext.Ielts.Domain.ParticipantsAggregate;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Persistence.ParticipantsAggregate.Mapping
{
    public class IeltsExamParticipantsDetailMapping : EntityMappingBase<IeltsExamParticipantsDetail>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<IeltsExamParticipantsDetail> builder)
        {
            builder.Property(p => p.ListeningExamId);
            builder.Property(p => p.ListeningExamIsGive);
            builder.Property(p => p.ListeningExamStartDateTime);
            builder.Property(p => p.ListeningExamEndDateTime);
            builder.Property(p => p.ListeningExamRegisterDateTime);

            builder.Property(p => p.ReadingExamId);
            builder.Property(p => p.ReadingExamIsGive);
            builder.Property(p => p.ReadingExamStartDateTime);
            builder.Property(p => p.ReadingExamEndDateTime);
            builder.Property(p => p.ReadingExamRegisterDateTime);

            builder.Property(p => p.WritingExamId);
            builder.Property(p => p.WritingExamIsGive);
            builder.Property(p => p.WritingExamStartDateTime);
            builder.Property(p => p.WritingExamEndDateTime);
            builder.Property(p => p.WritingExamRegisterDateTime);

            builder.Property(p => p.SpeakingExamId);
            builder.Property(p => p.SpeakingExamIsSetSession);

            builder.HasOne(e => e.IeltsExamParticipantsCurrent).WithMany(c => c.IeltsExamParticipantsDetailList).HasForeignKey(a => a.IeltsExamParticipantsId); //.OnDelete(DeleteBehavior.SetNull);
        }
    }
}
