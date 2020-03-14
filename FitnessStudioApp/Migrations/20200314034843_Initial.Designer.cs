﻿// <auto-generated />
using System;
using FitnessStudioApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FitnessStudioApp.Migrations
{
    [DbContext(typeof(FitnessStudioContext))]
    [Migration("20200314034843_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FitnessStudioApp.CustomerAccount", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassTitle")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CustomerSince")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateofBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("MembershipExpires")
                        .HasColumnType("datetime2");

                    b.Property<int>("TypeOfClassPass")
                        .HasColumnType("int");

                    b.Property<int>("TypeOfMembership")
                        .HasColumnType("int");

                    b.HasKey("CustomerID")
                        .HasName("PK_CustomerAccounts");

                    b.ToTable("CustomerAccounts");
                });

            modelBuilder.Entity("FitnessStudioApp.FitnessClass", b =>
                {
                    b.Property<int>("ClassTitle")
                        .HasColumnType("int");

                    b.Property<string>("ClassDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClassSize")
                        .HasColumnType("int");

                    b.Property<string>("ClassTimings")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DaysClassOffered")
                        .HasColumnType("int");

                    b.Property<string>("EndDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instructor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MinimumAge")
                        .HasColumnType("int");

                    b.Property<string>("StartDate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClassTitle")
                        .HasName("PK_ClassTitle");

                    b.ToTable("FitnessClasses");
                });

            modelBuilder.Entity("FitnessStudioApp.Transaction", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.HasKey("TransactionID")
                        .HasName("PK_Transactions");

                    b.HasIndex("CustomerID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("FitnessStudioApp.Transaction", b =>
                {
                    b.HasOne("FitnessStudioApp.CustomerAccount", "CustomerAccount")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
