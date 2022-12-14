﻿// <auto-generated />
using KD12MVCHamburger.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KD12MVCHamburger.Migrations
{
    [DbContext(typeof(HamburgerDbContext))]
    [Migration("20221104070444_mig_1")]
    partial class mig_1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("KD12MVCHamburger.Data.Ekstra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EkstraAdı")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Ekstralar");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EkstraAdı = "Ketçap",
                            Fiyat = 2m
                        },
                        new
                        {
                            Id = 2,
                            EkstraAdı = "Mayonez",
                            Fiyat = 4m
                        },
                        new
                        {
                            Id = 3,
                            EkstraAdı = "Ranch",
                            Fiyat = 8m
                        });
                });

            modelBuilder.Entity("KD12MVCHamburger.Data.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("MenuAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Menuler");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Fiyat = 45m,
                            MenuAd = "Whopper"
                        },
                        new
                        {
                            Id = 2,
                            Fiyat = 60m,
                            MenuAd = "Double Whopper"
                        },
                        new
                        {
                            Id = 3,
                            Fiyat = 65m,
                            MenuAd = "Double Köfte Burger"
                        },
                        new
                        {
                            Id = 4,
                            Fiyat = 55m,
                            MenuAd = "Cheeseburger"
                        });
                });

            modelBuilder.Entity("KD12MVCHamburger.Data.Siparis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Adet")
                        .HasColumnType("int");

                    b.Property<bool>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<string>("Boyut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ekstralar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<decimal>("ToplamTutar")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("Siparisler");
                });

            modelBuilder.Entity("KD12MVCHamburger.Data.Siparis", b =>
                {
                    b.HasOne("KD12MVCHamburger.Data.Menu", "SecilenMenu")
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SecilenMenu");
                });
#pragma warning restore 612, 618
        }
    }
}