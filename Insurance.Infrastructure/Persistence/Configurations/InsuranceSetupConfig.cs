using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Domain.Entities;


namespace Insurance.Infrastructure.Persistence.Configurations
{
    public class InsuranceSetupConfig : IEntityTypeConfiguration<InsuranceSetup>
    {
        public void Configure(EntityTypeBuilder<InsuranceSetup> builder)
        {
            builder.ToTable("InsuranceSetup");

            builder.HasKey(t => t.InsuranceSetupId)
                    .HasName("PK_InsuranceSetup_InsuranceSetupId")
                    .IsClustered();

            builder.Property(t => t.InsuranceSetupId);

            builder.Property(t => t.SetupName)
                    .IsRequired();

            builder.Property(t => t.MinAge)
                .IsRequired();

            builder.Property(t => t.MaxAge)
                .IsRequired();

            builder.Property(t => t.MinRange)
                .IsRequired();

            builder.Property(t => t.MaxRange)
                .IsRequired();

            builder.Property(t => t.Increments)
                .IsRequired();

            builder.Property(t => t.GuaranteedIssue)
                .HasPrecision(18,6)
                .IsRequired();
                        
        }
    }
}
