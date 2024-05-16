﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ÆGTESemesterProjekt.EFDbContext;

#nullable disable

namespace ÆGTESemesterProjekt.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    partial class ProductDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ÆGTESemesterProjekt.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("FinalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("userId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("ÆGTESemesterProjekt.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ÆGTESemesterProjekt.Models.Repair", b =>
                {
                    b.Property<int>("CaseId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EstDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("RepPrice")
                        .HasColumnType("float");

                    b.Property<string>("RepProduct")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RepairStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("SubDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CaseId");

                    b.ToTable("Repair");
                });

            modelBuilder.Entity("ÆGTESemesterProjekt.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ÆGTESemesterProjekt.Models.Wishlist", b =>
                {
                    b.Property<int>("WishlistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WishlistId"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("WishlistId");

                    b.HasIndex("ProductId");

                    b.HasIndex("userId");

                    b.ToTable("Wishlist");
                });

            modelBuilder.Entity("ÆGTESemesterProjekt.Models.Order", b =>
                {
                    b.HasOne("ÆGTESemesterProjekt.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ÆGTESemesterProjekt.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ÆGTESemesterProjekt.Models.Wishlist", b =>
                {
                    b.HasOne("ÆGTESemesterProjekt.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ÆGTESemesterProjekt.Models.User", "User")
                        .WithMany("WishlistProducts")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ÆGTESemesterProjekt.Models.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("WishlistProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
