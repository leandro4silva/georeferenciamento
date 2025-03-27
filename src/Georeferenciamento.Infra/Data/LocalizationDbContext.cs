using Georeferenciamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Georeferenciamento.Infra.Data;

public class LocalizationDbContext : DbContext
{
    public LocalizationDbContext(DbContextOptions<LocalizationDbContext> options) : base(options)
    {
    }

    public DbSet<State> States { get; set; }
    public DbSet<Cities> Cities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(s => s.StatePostalCode);
            entity.Property(s => s.StatePostalCode)
                .HasMaxLength(2)
                .IsFixedLength();  // This should now work with the proper using directives
            entity.Property(s => s.Name).IsRequired().HasMaxLength(100);
            entity.Property(s => s.Capital).IsRequired().HasMaxLength(100);
            entity.HasMany(s => s.Cities)
                .WithOne(c => c.State)
                .HasForeignKey(c => c.StatePostalCode);
        });

        modelBuilder.Entity<Cities>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).ValueGeneratedOnAdd();
            entity.Property(c => c.City).IsRequired().HasMaxLength(100);
            entity.HasIndex(c => new { c.StatePostalCode, c.City }).IsUnique();
        });
    }
}