using Microsoft.EntityFrameworkCore;
using Nutra.Domain.Entidades;
using Nutra.Domain.Repository;

namespace Nutra.API.Infrastructure.Repository;

public class DesafiosRepository : IDesafiosRepository
{
    private readonly ApplicationDbContext _context;

    public DesafiosRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Desafios?> ObterPorIdAsync(int id)
    {
        return await _context.Desafios
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<Desafios?> ObterPorTipoRegistroAsync(TipoRegistro tipoRegistro)
    {
        return await _context.Desafios
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.IdTipoRegistro == tipoRegistro.Id);
    }
}
