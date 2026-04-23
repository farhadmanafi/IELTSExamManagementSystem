using Framework.Persistence;
using ExamContext.General.Domain.MenuAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.General.Persistence.MenuAggregate.Mapping
{
    public class MenuMapping : EntityMappingBase<Menu>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<Menu> builder)
        {
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.ParentMenuId);
            builder.Property(p => p.OrderNo);
            builder.Property(p => p.Url).IsRequired();
            builder.Property(p => p.PageName).IsRequired();
            builder.Property(p => p.Icon).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();
        }
    }
}
