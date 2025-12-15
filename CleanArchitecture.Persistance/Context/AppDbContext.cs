using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Persistance.Context;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);

    public override Task<int> SaveChangesAsync( CancellationToken cancellationToken = default)
    {
        var entities = ChangeTracker.Entries<Entity>();
        foreach (var item in entities)
        {
            if (item.State == EntityState.Added) 
                    item.Property(p=> p.CreatedDate).CurrentValue = DateTime.UtcNow;

            if (item.State == EntityState.Modified)
                item.Property(p => p.UpdatedDate).CurrentValue = DateTime.UtcNow;
        }
        return base.SaveChangesAsync( cancellationToken);
    }

}
