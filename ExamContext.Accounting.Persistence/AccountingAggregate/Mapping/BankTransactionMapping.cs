using ExamContext.Accounting.Domain.AccountingAggregate;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Accounting.Persistence.AccountingAggregate.Mapping
{
    public class BankTransactionMapping : EntityMappingBase<BankTransaction>, IEntityMapping
    {
        protected override void OnConfigure(EntityTypeBuilder<BankTransaction> builder)
        {
            builder.Property(p => p.ParticipantsId).IsRequired();
            builder.Property(p => p.PaymentDateTime).IsRequired();
            builder.Property(p => p.PaymentPriceAmount).IsRequired();
            builder.Property(p => p.BankTransactionCode).IsRequired();
            builder.Property(p => p.CustomerAccountNumber).IsRequired();
            builder.Property(p => p.PaymentFinished).IsRequired();
            builder.Property(p => p.BankName).IsRequired();
            builder.Property(p => p.CustomerId).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.IsDeleted).IsRequired();

            builder.HasOne(e => e.BankTransactionTypeCurrent).WithMany(c => c.BankTransactionList).HasForeignKey(a => a.BankTransactionTypeId); //.OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(e => e.ExamTypeCurrent).WithMany(c => c.BankTransactionList).HasForeignKey(a => a.ExamTypeId); //.OnDelete(DeleteBehavior.SetNull);
        }
    }
}
