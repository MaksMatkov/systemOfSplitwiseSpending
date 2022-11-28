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
    class PaymantsConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(el => el.Id);
            builder.Property(u => u.Id).UseIdentityColumn(1, 1).ValueGeneratedOnAdd();

            builder.HasOne(el => el.FromUser).WithMany(el => el.PaymantFrom).HasForeignKey(el => el.FromUserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(el => el.ToUser).WithMany(el => el.PaymantTo).HasForeignKey(el => el.ToUserId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(el => el.Group).WithMany(el => el.PaymantItems).HasForeignKey(el => el.GroupId);

            builder.Property(u => u.Description);
            builder.Property(u => u.Confirmed);
            builder.Property(u => u.Amount);
            builder.Property(u => u.Time);
            builder.Property(u => u.GroupId);
            builder.Property(u => u.ToUserId);
            builder.Property(u => u.FromUserId);
        }
    }
}
