using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SplitWise.Domain.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.Infrastucture.ModelsConfigurations
{
    class ExpenseListConfiguration : IEntityTypeConfiguration<ExpenseList>
    {
        public void Configure(EntityTypeBuilder<ExpenseList> builder)
        {
            builder.HasKey(el => new { el.ExpenseHeaderId, el.UserId });
            
            builder.HasOne(el => el.User).WithMany(u => u.ExpenseLists).HasForeignKey(el => el.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(el => el.ExpenseHeader).WithMany(eh => eh.ExpenseList).HasForeignKey(el => el.ExpenseHeaderId);

            builder.Property(el => el.Amount)
            .HasColumnType("decimal(10, 2)");
            builder.Property(el => el.UserId);
            builder.Property(el => el.ExpenseHeaderId);
        }
    }
}
