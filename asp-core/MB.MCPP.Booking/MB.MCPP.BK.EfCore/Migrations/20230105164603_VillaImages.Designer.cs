﻿// <auto-generated />
using System;
using MB.MCPP.BK.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MB.MCPP.BK.EfCore.Migrations
{
    [DbContext(typeof(BookingDbContext))]
    [Migration("20230105164603_VillaImages")]
    partial class VillaImages
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AddonVilla", b =>
                {
                    b.Property<int>("AddonsId")
                        .HasColumnType("int");

                    b.Property<int>("VillasId")
                        .HasColumnType("int");

                    b.HasKey("AddonsId", "VillasId");

                    b.HasIndex("VillasId");

                    b.ToTable("AddonVilla");
                });

            modelBuilder.Entity("MB.MCPP.BK.Entities.Addon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Addons");
                });

            modelBuilder.Entity("MB.MCPP.BK.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BookingEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BookingStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfOccupants")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<int>("VillaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("VillaId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("MB.MCPP.BK.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MB.MCPP.BK.Entities.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBooked")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("NumberOfOccupants")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Villas");
                });

            modelBuilder.Entity("MB.MCPP.BK.Entities.VillaImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VillaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VillaId");

                    b.ToTable("VillaImages");
                });

            modelBuilder.Entity("AddonVilla", b =>
                {
                    b.HasOne("MB.MCPP.BK.Entities.Addon", null)
                        .WithMany()
                        .HasForeignKey("AddonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MB.MCPP.BK.Entities.Villa", null)
                        .WithMany()
                        .HasForeignKey("VillasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MB.MCPP.BK.Entities.Booking", b =>
                {
                    b.HasOne("MB.MCPP.BK.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MB.MCPP.BK.Entities.Villa", "Villa")
                        .WithMany()
                        .HasForeignKey("VillaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Villa");
                });

            modelBuilder.Entity("MB.MCPP.BK.Entities.VillaImage", b =>
                {
                    b.HasOne("MB.MCPP.BK.Entities.Villa", null)
                        .WithMany("VillaImages")
                        .HasForeignKey("VillaId");
                });

            modelBuilder.Entity("MB.MCPP.BK.Entities.Villa", b =>
                {
                    b.Navigation("VillaImages");
                });
#pragma warning restore 612, 618
        }
    }
}
