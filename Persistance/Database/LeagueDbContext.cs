using Microsoft.EntityFrameworkCore;
using Persistance.Database.Entities;
using Persistance.Database.Interfaces;

namespace Persistance.Database;

public class LeagueDbContext : DbContext
{
    public LeagueDbContext(DbContextOptions<LeagueDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}