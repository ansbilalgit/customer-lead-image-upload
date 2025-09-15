using CompanyPlanner.Infrastructure.Entitities;
using Microsoft.EntityFrameworkCore;

namespace CompanyPlanner.DataService.DBContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerImage> CustomerImages { get; set; }

        public DbSet<Lead> Leads { get; set; }
        public DbSet<LeadImage> LeadImages { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CustomerImage>().Property(i => i.Base64Data).HasMaxLength(4_000_000);
            modelBuilder.Entity<LeadImage>().Property(i => i.Base64Data).HasMaxLength(4_000_000);
        }
    }

}
