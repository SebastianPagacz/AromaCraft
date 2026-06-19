using System;
using AromaCraft.Domain.Models;
using AromaCraft.Domain.Repository;
using AromaCraft.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AromaCraft.Infrastructure.Repository;

public class ProductRepository(AppDbContext _context) : IRepository<Product>
{
    public void Add(Product item)
    {
        _context.Add(item);
    }

    public async Task<List<Product>> GetAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Products.ToListAsync(cancellationToken);
    }

    public async Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);
    }
}
