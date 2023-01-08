using MB.MCPP.BK.Entities;
using Microsoft.EntityFrameworkCore;

namespace MB.MCPP.BK.EfCore
{
    public class BookingDbContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Villa> Villas { get; set; }
        public DbSet<Addon> Addons { get; set; }
        public DbSet<VillaImage> VillaImages { get; set; }


        public BookingDbContext(DbContextOptions<BookingDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>()
                        .HasIndex(v => v.Name)
                        .IsUnique();

            modelBuilder.Entity<VillaImage>()
                        .HasIndex(v => v.Name)
                        .IsUnique();
        }
    }
}
