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
    public class IeltsExamParticipantsStatusMapping : EntityMappingBase<IeltsExamParticipantsStatus>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<IeltsExamParticipantsStatus> builder)
        {
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.IsActive);
            builder.Property(p => p.IsDeleted);
        }
    }
}
