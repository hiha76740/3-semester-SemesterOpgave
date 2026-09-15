using AccomodationService.DomainLib.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccomodationService.InfrastructureLib.Persistence;

public class AccomodationDbContext : DbContext
{
    public DbSet<Accomodation> Accomodations { get; set; }


}
