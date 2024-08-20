using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TicketConfigurations());
        modelBuilder.ApplyConfiguration(new GovernorateConfigurations());
        modelBuilder.ApplyConfiguration(new CityConfigurations());
        modelBuilder.ApplyConfiguration(new DistrictConfigurations());
    }

    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Governorate> Governorates { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<District> Districts { get; set; }
}
