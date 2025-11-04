using Microsoft.EntityFrameworkCore;
using Nutra.API.Data;
using Nutra.Domain.Entidades;
using Nutra.Domain.Repository;

namespace Nutra.API.Infrastructure;

public class EfOrderRepository : IOrderRepository
{
    private readonly NutraDbContext _db;

    public EfOrderRepository(NutraDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<OrderEntity>> GetAll(CancellationToken cancellationToken)
    {
        return await _db.Orders.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<OrderEntity?> GetById(string id, CancellationToken cancellationToken)
    {
        return await _db.Orders.FindAsync(new object?[] { id }, cancellationToken);
    }

    public async Task Add(OrderEntity order, CancellationToken cancellationToken)
    {
        await _db.Orders.AddAsync(order, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(OrderEntity order, CancellationToken cancellationToken)
    {
        _db.Orders.Update(order);
        await _db.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(string id, CancellationToken cancellationToken)
    {
        var existing = await GetById(id, cancellationToken);
        if (existing != null)
        {
            _db.Orders.Remove(existing);
            await _db.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task<int> GetTotalCount(CancellationToken cancellationToken)
    {
        return await _db.Orders.CountAsync(cancellationToken);
    }

    public async Task<decimal> GetTotalRevenue(CancellationToken cancellationToken)
    {
        return await _db.Orders.SumAsync(o => o.TotalAmount, cancellationToken);
    }
}


