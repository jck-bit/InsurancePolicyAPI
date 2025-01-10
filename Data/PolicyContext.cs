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
    }
}
