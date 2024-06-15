using Domain.Entities;
using Infrastructure.Dal.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.EntityFramework;
/// <summary>
/// Database Context
/// </summary>
public class DexBotDbContext : DbContext
{
    /// <summary>
    /// Persons DbSet
    /// </summary>
    public DbSet<Person> Persons { get; set; }
    /// <summary>
    /// CustomFields DbSet
    /// </summary>
    public DbSet<CustomFields<string>> CustomFields { get; set; }

    public DexBotDbContext(DbContextOptions<DexBotDbContext> options) : base(options)
    {
    }
    /// <summary>
    /// Применение конфигураций для таблиц
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new PersonConfiguration());
        modelBuilder.ApplyConfiguration(new CustomFieldsConfiguration());
    }
}