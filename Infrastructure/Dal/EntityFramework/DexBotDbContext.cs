using Domain.Entities;
using Infrastructure.Dal.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Dal.EntityFramework;

public class DexBotDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    
    public DbSet<CustomFields<string>> CustomFields { get; set; }

    public DexBotDbContext(DbContextOptions<DexBotDbContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseNpgsql("User ID=postgres;Password= mysecretpassword;Host=localhost;Port=5432;Database=postgres;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new PersonConfiguration());
        modelBuilder.ApplyConfiguration(new CustomFieldsConfiguration());
    }
}