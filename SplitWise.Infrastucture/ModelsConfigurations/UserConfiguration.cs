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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).UseIdentityColumn(1, 1).ValueGeneratedOnAdd();

            builder.HasMany(el => el.UserGroups).WithOne(el => el.User).HasForeignKey(el => el.UserId);
            builder.HasMany(el => el.ExpenseHeaders).WithOne(el => el.User).HasForeignKey(el => el.UserId);
            builder.HasMany(el => el.ExpenseLists).WithOne(el => el.User).HasForeignKey(el => el.UserId);

            builder.HasMany(el => el.PaymantFrom).WithOne(el => el.FromUser).HasForeignKey(el => el.FromUserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(el => el.PaymantTo).WithOne(el => el.ToUser).HasForeignKey(el => el.ToUserId).OnDelete(DeleteBehavior.Restrict);

            builder.Property(u => u.Name).HasMaxLength(20);
            builder.Property(u => u.Password).HasMaxLength(30);
        }
    }
}
