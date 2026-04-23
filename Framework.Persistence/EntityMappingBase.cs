using Framework.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Persistence
{
    public abstract class EntityMappingBase<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : EntityBase
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            Initial(builder);

            this.OnConfigure(builder);
        }

        protected abstract void OnConfigure(EntityTypeBuilder<TEntity> builder);

        protected void Initial(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.HasKey(p => p.Id);
        }
    }
}
