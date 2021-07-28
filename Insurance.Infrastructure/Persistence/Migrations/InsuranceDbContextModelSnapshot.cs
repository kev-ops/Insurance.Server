﻿// <auto-generated />
using System;
using Insurance.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Insurance.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(InsuranceDbContext))]
    partial class InsuranceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Insurance.Domain.Entities.BenefitsDetail", b =>
                {
                    b.Property<int>("BenefitsDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Benefits")
                        .HasPrecision(18, 6)
                        .HasColumnType("decimal(18,6)");

                    b.Property<decimal>("Benefits_Amount_Quotation")
                        .HasPrecision(18, 6)
                        .HasColumnType("decimal(18,6)");

                    b.Property<int>("ConsumerId")
                        .HasColumnType("int");

                    b.Property<int>("Multiple")
                        .HasColumnType("int");

                    b.Property<decimal>("Pended_Amount")
                        .HasPrecision(18, 6)
                        .HasColumnType("decimal(18,6)");

                    b.HasKey("BenefitsDetailId")
                        .HasName("PK_BenefitsDetail_BenefitsDetailId")
                        .IsClustered();

                    b.HasIndex("ConsumerId");

                    b.ToTable("BenefitsDetail");
                });

            modelBuilder.Entity("Insurance.Domain.Entities.Consumer", b =>
                {
                    b.Property<int>("ConsumerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<decimal>("BasicSalary")
                        .HasPrecision(18, 6)
                        .HasColumnType("decimal(18,6)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConsumerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("InsuranceSetupId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.HasKey("ConsumerId")
                        .HasName("PK_Consumer_ConsumerId")
                        .IsClustered();

                    b.HasIndex("InsuranceSetupId");

                    b.ToTable("Consumer");
                });

            modelBuilder.Entity("Insurance.Domain.Entities.InsuranceSetup", b =>
                {
                    b.Property<int>("InsuranceSetupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("GuaranteedIssue")
                        .HasPrecision(18, 6)
                        .HasColumnType("decimal(18,6)");

                    b.Property<int>("Increments")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaxAge")
                        .HasColumnType("int");

                    b.Property<int>("MaxRange")
                        .HasColumnType("int");

                    b.Property<int>("MinAge")
                        .HasColumnType("int");

                    b.Property<int>("MinRange")
                        .HasColumnType("int");

                    b.Property<string>("SetupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InsuranceSetupId")
                        .HasName("PK_InsuranceSetup_InsuranceSetupId")
                        .IsClustered();

                    b.ToTable("InsuranceSetup");
                });

            modelBuilder.Entity("Insurance.Domain.Entities.BenefitsDetail", b =>
                {
                    b.HasOne("Insurance.Domain.Entities.Consumer", "Consumer")
                        .WithMany("BenefitsDetails")
                        .HasForeignKey("ConsumerId")
                        .HasConstraintName("FK_BenefitsDetail_Consumer_ConsumerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consumer");
                });

            modelBuilder.Entity("Insurance.Domain.Entities.Consumer", b =>
                {
                    b.HasOne("Insurance.Domain.Entities.InsuranceSetup", "InsuranceSetup")
                        .WithMany("Consumers")
                        .HasForeignKey("InsuranceSetupId")
                        .HasConstraintName("FK_Consumer_InsuranceSetup_InsuranceSetupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("InsuranceSetup");
                });

            modelBuilder.Entity("Insurance.Domain.Entities.Consumer", b =>
                {
                    b.Navigation("BenefitsDetails");
                });

            modelBuilder.Entity("Insurance.Domain.Entities.InsuranceSetup", b =>
                {
                    b.Navigation("Consumers");
                });
#pragma warning restore 612, 618
        }
    }
}
