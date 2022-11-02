using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace MB.MCPP.BK.EfCore
{
    public class BookingContextFactory : IDesignTimeDbContextFactory<BookingDbContext>
    {
        public BookingDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BookingDbContext>();
            optionsBuilder
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BookingApp;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new BookingDbContext(optionsBuilder.Options);
        }
    }
}
