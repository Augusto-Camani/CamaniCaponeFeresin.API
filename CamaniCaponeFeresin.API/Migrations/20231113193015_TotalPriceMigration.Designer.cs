﻿// <auto-generated />
using System;
using CamaniCaponeFeresin.API.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CamaniCaponeFeresin.API.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20231113193015_TotalPriceMigration")]
    partial class TotalPriceMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("CamaniCaponeFeresin.API.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SaleLineId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SaleLineId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Guitarra criolla",
                            Name = "Guitarra",
                            Price = 30000m
                        });
                });

            modelBuilder.Entity("CamaniCaponeFeresin.API.Entities.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Sales", (string)null);
                });

            modelBuilder.Entity("CamaniCaponeFeresin.API.Entities.SaleLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SaleId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleId");

                    b.ToTable("SaleLines", (string)null);
                });

            modelBuilder.Entity("CamaniCaponeFeresin.API.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<int>("UserType");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("CamaniCaponeFeresin.API.Entities.Admin", b =>
                {
                    b.HasBaseType("CamaniCaponeFeresin.API.Entities.User");

                    b.HasDiscriminator().HasValue(0);

                    b.HasData(
                        new
                        {
                            Id = 4,
                            Email = "augustocamaniadmin@gmail.com",
                            Password = "1342",
                            UserName = "ElSysAdmin",
                            UserType = 0
                        });
                });

            modelBuilder.Entity("CamaniCaponeFeresin.API.Entities.Client", b =>
                {
                    b.HasBaseType("CamaniCaponeFeresin.API.Entities.User");

                    b.ToTable("Users", (string)null);

                    b.HasDiscriminator().HasValue(1);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "augustocamani@gmail.com",
                            Password = "1234",
                            UserName = "Enano",
                            UserType = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "santinocapone@gmail.com",
                            Password = "4321",
                            UserName = "CaponeCapo",
                            UserType = 1
                        },
                        new
                        {
                            Id = 3,
                            Email = "santiagoferesin@gmail.com",
                            Password = "3412",
                            UserName = "ElFere",
                            UserType = 1
                        });
                });

            modelBuilder.Entity("CamaniCaponeFeresin.API.Entities.Product", b =>
                {
                    b.HasOne("CamaniCaponeFeresin.API.Entities.SaleLine", null)
                        .WithMany("Products")
                        .HasForeignKey("SaleLineId");
                });

            modelBuilder.Entity("CamaniCaponeFeresin.API.Entities.Sale", b =>
                {
                    b.HasOne("CamaniCaponeFeresin.API.Entities.Client", "Client")
                        .WithMany("Sales")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("CamaniCaponeFeresin.API.Entities.SaleLine", b =>
                {
                    b.HasOne("CamaniCaponeFeresin.API.Entities.Product", "Product")
                        .WithMany("SaleLines")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CamaniCaponeFeresin.API.Entities.Sale", "Sale")
                        .WithMany("SaleLines")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("CamaniCaponeFeresin.API.Entities.Product", b =>
                {
                    b.Navigation("SaleLines");
                });

            modelBuilder.Entity("CamaniCaponeFeresin.API.Entities.Sale", b =>
                {
                    b.Navigation("SaleLines");
                });

            modelBuilder.Entity("CamaniCaponeFeresin.API.Entities.SaleLine", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("CamaniCaponeFeresin.API.Entities.Client", b =>
                {
                    b.Navigation("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}
