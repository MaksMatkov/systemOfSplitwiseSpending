using Microsoft.EntityFrameworkCore;
using SplitWise.Domain.Enteties;
using SplitWise.Infrastucture.Infrastructure;
using SplitWise.Infrastucture.ModelsConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitWise.Infrastucture
{
    public class splitwiseContext : DbContext
    {
        private string connectionString { get; set; }

        public DbSet<User> User { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<ExpenseHeader> ExpenseHeaders { get; set; }
        public DbSet<ExpenseList> ExpenseLists { get; set; }
        public DbSet<Payment> Paymants { get; set; }

      
        public splitwiseContext(ConnectionStringsConfiguration ConnectionStringsConfiguration) : base()
        {
            this.connectionString = ConnectionStringsConfiguration.Main;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new UserGroupConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseHeaderConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseListConfiguration());
        }
    }
}
