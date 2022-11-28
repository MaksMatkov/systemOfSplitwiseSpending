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
    class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(el => el.Id);
            builder.Property(el => el.Id).UseIdentityColumn(1, 1).ValueGeneratedOnAdd();

            builder.HasMany(el => el.PaymantItems).WithOne(el => el.Group).HasForeignKey(el => el.GroupId);
            builder.HasMany(el => el.ExpenseHeaders).WithOne(el => el.Group).HasForeignKey(el => el.GroupId);
            builder.HasMany(el => el.UserGroups).WithOne(el => el.Group).HasForeignKey(el => el.GroupId);

            builder.Property(el => el.Name).HasMaxLength(30);
        }
    }
}
