using System;
using AromaCraft.Domain.Models;
using AromaCraft.Domain.Repository;
using AromaCraft.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AromaCraft.Infrastructure.Context;

public class AppDbContext : DbContext, IUnitOfWork
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InfrastructureDependencyInjection).Assembly);
    }

    Task IUnitOfWork.SaveChangesAsync(CancellationToken cancellationToken)
    {
        return SaveChangesAsync(cancellationToken);
    }

    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Product> Products { get; set; }
}
