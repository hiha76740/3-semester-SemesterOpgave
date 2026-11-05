using BookingService.DomainLib.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingService.InfrastructureLib.Persistence
{
    public class BookingDbContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }

        public BookingDbContext(DbContextOptions<BookingDbContext > options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("BookingNumbers")
                .StartsAt(1000)
                .IncrementsBy(1);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookingDbContext).Assembly);

        }
        
    }
}
