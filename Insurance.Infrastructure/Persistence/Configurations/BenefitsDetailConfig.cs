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
    public class BenefitsDetailConfig : IEntityTypeConfiguration<BenefitsDetail>
    {
        public void Configure(EntityTypeBuilder<BenefitsDetail> builder)
        {
            builder.ToTable("BenefitsDetail");

            builder.HasKey(t => t.BenefitsDetailId)
                    .HasName("PK_BenefitsDetail_BenefitsDetailId")
                    .IsClustered();

            builder.Property(t => t.BenefitsDetailId)
                    .IsRequired();

            builder.Property(t => t.Multiple)
                    .IsRequired();

            builder.Property(t => t.Benefits_Amount_Quotation)
                    .HasPrecision(18, 6)
                    .IsRequired();

            builder.Property(t => t.Pended_Amount)
                    .HasPrecision(18,6)
                    .IsRequired();

            builder.Property(t => t.Benefits)
                    .HasPrecision(18, 6);
                  

            builder.Property(t => t.Multiple)
                    .IsRequired();


            builder.HasOne(o => o.Consumer)
                    .WithMany(o => o.BenefitsDetails)
                    .HasForeignKey(o => o.ConsumerId)
                    .HasConstraintName("FK_BenefitsDetail_Consumer_ConsumerId");


        }
    }
}
