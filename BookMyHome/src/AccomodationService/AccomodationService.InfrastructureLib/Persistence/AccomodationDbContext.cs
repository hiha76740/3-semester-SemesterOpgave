using AccomodationService.DomainLib.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccomodationService.InfrastructureLib.Persistence;

public class AccomodationDbContext : DbContext
{
    public DbSet<Accomodation> Accomodations { get; set; }

    public DbSet<Listing> Listings { get; set; }

    public DbSet<Facility> Facilities { get; set; }

    public AccomodationDbContext(DbContextOptions<AccomodationDbContext> options  ) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccomodationDbContext).Assembly);
    }


}
