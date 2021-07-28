using Insurance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Infrastructure.Persistence.Configurations
{
    public class ConsumerConfig : IEntityTypeConfiguration<Consumer>
    {
        public void Configure(EntityTypeBuilder<Consumer> builder)
        {
            builder.ToTable("Consumer");

            builder.HasKey(t => t.ConsumerId)
                    .HasName("PK_Consumer_ConsumerId")
                    .IsClustered();

            builder.Property(t => t.ConsumerName)
                    .IsRequired();

            builder.Property(t => t.BasicSalary)
                    .HasPrecision(18,6)
                    .IsRequired();

            builder.Property(t => t.BirthDate)
                    .IsRequired();

            builder.Property(t => t.Age);

            builder.Property(t => t.CreatedDate);

            builder.Property(t => t.LastModified);

            builder.Property(t => t.InsuranceSetupId);


            builder.HasOne(o => o.InsuranceSetup)
                        .WithMany(o => o.Consumers)
                        .HasForeignKey(o => o.InsuranceSetupId)
                        .HasConstraintName("FK_Consumer_InsuranceSetup_InsuranceSetupId")
                        .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
