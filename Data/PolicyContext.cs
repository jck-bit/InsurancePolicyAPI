using Microsoft.EntityFrameworkCore;
using InsurancePolicyAPI.Models;

namespace InsurancePolicyAPI.Data
{
    public class PolicyContext : DbContext
    {
        public PolicyContext(DbContextOptions<PolicyContext> options) : base(options) 
        {
            Policies = Set<Policy>();
        }

        public DbSet<Policy> Policies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Policy>()
                .Property(p => p.Premium)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Policy>()
                .Property(p => p.Coverage)
                .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
