using AromaCraft.Domain.Models;
using AromaCraft.Domain.Repository;
using AromaCraft.Infrastructure.Context;
using AromaCraft.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AromaCraft.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(o => 
            o.UseInMemoryDatabase("TestDb"));

        services.AddScoped<IRepository<Product>, ProductRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<AppDbContext>());
        
        return services;
    }
}
