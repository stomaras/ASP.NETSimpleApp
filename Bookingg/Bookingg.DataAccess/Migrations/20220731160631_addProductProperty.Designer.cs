﻿// <auto-generated />
using System;
using Bookingg.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bookingg.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220731160631_addProductProperty")]
    partial class addProductProperty
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Booking.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDateTime = new DateTime(2022, 7, 31, 19, 6, 31, 227, DateTimeKind.Local).AddTicks(808),
                            DisplayOrder = 1,
                            Name = "Vans"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDateTime = new DateTime(2022, 7, 31, 19, 6, 31, 227, DateTimeKind.Local).AddTicks(856),
                            DisplayOrder = 2,
                            Name = "Adidas"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDateTime = new DateTime(2022, 7, 31, 19, 6, 31, 227, DateTimeKind.Local).AddTicks(860),
                            DisplayOrder = 3,
                            Name = "Nike"
                        },
                        new
                        {
                            Id = 4,
                            CreatedDateTime = new DateTime(2022, 7, 31, 19, 6, 31, 227, DateTimeKind.Local).AddTicks(865),
                            DisplayOrder = 4,
                            Name = "Volcom"
                        });
                });

            modelBuilder.Entity("Booking.Models.CoverType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CoverTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fabric",
                            Price = 20
                        },
                        new
                        {
                            Id = 2,
                            Name = "Leather",
                            Price = 15
                        },
                        new
                        {
                            Id = 3,
                            Name = "Vegan",
                            Price = 9
                        },
                        new
                        {
                            Id = 4,
                            Name = "Sofa",
                            Price = 35
                        });
                });

            modelBuilder.Entity("Booking.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CoverTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ListPrice")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Price100")
                        .HasColumnType("float");

                    b.Property<double>("Price50")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CoverTypeId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Booking.Models.Product", b =>
                {
                    b.HasOne("Booking.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Booking.Models.CoverType", "CoverType")
                        .WithMany()
                        .HasForeignKey("CoverTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("CoverType");
                });
#pragma warning restore 612, 618
        }
    }
}