using MB.MCPP.BK.Entities;
using MB.MCPP.BK.Entities.Addons;
using MB.MCPP.BK.Entities.Customers;
using MB.MCPP.BK.Entities.Villas;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace MB.MCPP.BK.EfCore
{
    public class BookingDbContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Villa> Villas { get; set; }
        public DbSet<Addon> Addons { get; set; }

        public DbSet<UploaderImage> UploaderImages { get; set; }
        public DbSet<CustomerImage> CustomerImages { get; set; }
        public DbSet<VillaImage> VillaImages { get; set; }
        public DbSet<AddonImage> AddonImages { get; set; }


        public BookingDbContext(DbContextOptions<BookingDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>()
                        .HasIndex(v => v.Name)
                        .IsUnique();

            modelBuilder.Entity<CustomerImage>()
                        .HasIndex(v => v.Name)
            .IsUnique();

            modelBuilder.Entity<UploaderImage>().UseTpcMappingStrategy()
                .ToTable("UploaderImages");

            modelBuilder.Entity<CustomerImage>()
                .ToTable("CustomerImages");

            modelBuilder.Entity<VillaImage>()
                .ToTable("VillaImages");

            modelBuilder.Entity<AddonImage>()
                .ToTable("AddonImages");
        }
    }
}
