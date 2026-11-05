using Microsoft.EntityFrameworkCore;
using UserService.DomainLib.Entities;

namespace UserService.InfrastructureLib.Persistence;

public class UserDbContext : DbContext
{
    public DbSet<User> Users { get; set; }


    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);
    }
}
