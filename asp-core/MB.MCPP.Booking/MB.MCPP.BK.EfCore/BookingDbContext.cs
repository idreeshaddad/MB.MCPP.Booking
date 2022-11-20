using MB.MCPP.BK.Entities;
using Microsoft.EntityFrameworkCore;

namespace MB.MCPP.BK.EfCore
{
    public class BookingDbContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Villa> Villas { get; set; }
        public DbSet<AddOn> AddOns { get; set; }


        public BookingDbContext(DbContextOptions<BookingDbContext> options)
            : base(options)
        {
        }

    }
}
