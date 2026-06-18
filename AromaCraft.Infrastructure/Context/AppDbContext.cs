using System;
using AromaCraft.Domain.Models;
using AromaCraft.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AromaCraft.Infrastructure.Context;

public class AppDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InfrastructureDependencyInjection).Assembly);
    }
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Product> Products { get; set; }
}
