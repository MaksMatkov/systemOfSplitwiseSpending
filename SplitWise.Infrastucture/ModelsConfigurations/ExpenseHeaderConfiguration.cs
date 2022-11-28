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
    class ExpenseHeaderConfiguration : IEntityTypeConfiguration<ExpenseHeader>
    {
        public void Configure(EntityTypeBuilder<ExpenseHeader> builder)
        {
            builder.HasKey(el => el.Id);
            builder.Property(el => el.Id).UseIdentityColumn(1, 1).ValueGeneratedOnAdd();

            builder.HasOne(eh => eh.User).WithMany(u => u.ExpenseHeaders).HasForeignKey(el => el.UserId); 
            builder.HasOne(eh => eh.Group).WithMany(g => g.ExpenseHeaders).HasForeignKey(el => el.GroupId);
            builder.HasMany(el => el.ExpenseList).WithOne(el => el.ExpenseHeader).HasForeignKey(el => el.ExpenseHeaderId);

            builder.Property(el => el.Description).HasMaxLength(200);
            builder.Property(eh => eh.UserId);
            builder.Property(eh => eh.GroupId);
            builder.Property(eh => eh.Date).HasDefaultValueSql("getdate()");
        }
    }
}
