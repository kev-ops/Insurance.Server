using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Domain.Entities;
using System.Reflection;

namespace Insurance.Infrastructure.Persistence
{
    public class InsuranceDbContext : DbContext
    {
        public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options)
        {
            
        }
        public DbSet<Consumer> Consumer { get; set; }
        public DbSet<BenefitsDetail> BenefitsDetails { get; set; }
        public DbSet<InsuranceSetup> InsuranceSetup { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());



            base.OnModelCreating(modelBuilder);
        }
    }
}
