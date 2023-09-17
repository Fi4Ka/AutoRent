﻿// <auto-generated />
using System;
using AutoRentWeb.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutoRentWeb.DAL.Migrations
{
    [DbContext(typeof(AutoRentDbContext))]
    [Migration("20230501091720_Second")]
    partial class Second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AutoRentWeb.DAL.Entity.Arendator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BankCardId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BankCardId")
                        .IsUnique()
                        .HasFilter("[BankCardId] IS NOT NULL");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Arendator");
                });

            modelBuilder.Entity("AutoRentWeb.DAL.Entity.Auto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Avatar")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("CompanyDelegateId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TypeCarId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyDelegateId");

                    b.HasIndex("TypeCarId");

                    b.ToTable("Auto");
                });

            modelBuilder.Entity("AutoRentWeb.DAL.Entity.BankCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Bill")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CVV")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BankCard");
                });

            modelBuilder.Entity("AutoRentWeb.DAL.Entity.Basket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArendatorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArendatorId")
                        .IsUnique();

                    b.ToTable("Basket");
                });

            modelBuilder.Entity("AutoRentWeb.DAL.Entity.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("AutoRentWeb.DAL.Entity.CompanyDelegate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("CompanyDelegate");
                });

            modelBuilder.Entity("AutoRentWeb.DAL.Entity.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AutoId")
                        .HasColumnType("int");

                    b.Property<int>("BasketId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("StatusOrder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AutoId");

                    b.HasIndex("BasketId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("AutoRentWeb.DAL.Entity.TypeCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeCar");
                });

            modelBuilder.Entity("AutoRentWeb.DAL.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("AutoRentWeb.DAL.Entity.Arendator", b =>
                {
                    b.HasOne("AutoRentWeb.DAL.Entity.BankCard", "BankCard")
                        .WithOne("Arendator")
                        .HasForeignKey("AutoRentWeb.DAL.Entity.Arendator", "BankCardId");

                    b.HasOne("AutoRentWeb.DAL.Entity.User", "User")
                        .WithOne("Arendator")
                        .HasForeignKey("AutoRentWeb.DAL.Entity.Arendator", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BankCard");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AutoRentWeb.DAL.Entity.Auto", b =>
                {
                    b.HasOne("AutoRentWeb.DAL.Entity.CompanyDelegate", "CompanyDelegate")
                        .WithMany("Autos")
                        .HasForeignKey("CompanyDelegateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoRentWeb.DAL.Entity.TypeCar", "TypeCar")
                        .WithMany("Autos")
                        .HasForeignKey("TypeCarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyDelegate");

                    b.Navigation("TypeCar");
                });

            modelBuilder.Entity("AutoRentWeb.DAL.Entity.Basket", b =>
                {
                    b.HasOne("AutoRentWeb.DAL.Entity.Arendator", "Arendator")
                        .WithOne("Basket")
                        .HasForeignKey("AutoRentWeb.DAL.Entity.Basket", "ArendatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Arendator");
                });

            modelBuilder.Entity("AutoRentWeb.DAL.Entity.CompanyDelegate", b =>
                {
                    b.HasOne("AutoRentWeb.DAL.Entity.Company", "Company")
                        .WithOne("CompanyDelegate")
                        .HasForeignKey("AutoRentWeb.DAL.Entity.CompanyDelegate", "CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoRentWeb.DAL.Entity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AutoRentWeb.DAL.Entity.Order", b =>
                {
                    b.HasOne("AutoRentWeb.DAL.Entity.Auto", "Auto")
                        .WithMany()
                        .HasForeignKey("AutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoRentWeb.DAL.Entity.Basket", "Basket")
                        .WithMany("Orders")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auto");

                    b.Navigation("Basket");
                });

            modelBuilder.Entity("AutoRentWeb.DAL.Entity.Arendator", b =>
                {
                    b.Navigation("Basket");
                });

            modelBuilder.Entity("AutoRentWeb.DAL.Entity.BankCard", b =>
                {
                    b.Navigation("Arendator");
                });

            modelBuilder.Entity("AutoRentWeb.DAL.Entity.Basket", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("AutoRentWeb.DAL.Entity.Company", b =>
                {
                    b.Navigation("CompanyDelegate");
                });

            modelBuilder.Entity("AutoRentWeb.DAL.Entity.CompanyDelegate", b =>
                {
                    b.Navigation("Autos");
                });

            modelBuilder.Entity("AutoRentWeb.DAL.Entity.TypeCar", b =>
                {
                    b.Navigation("Autos");
                });

            modelBuilder.Entity("AutoRentWeb.DAL.Entity.User", b =>
                {
                    b.Navigation("Arendator");
                });
#pragma warning restore 612, 618
        }
    }
}
