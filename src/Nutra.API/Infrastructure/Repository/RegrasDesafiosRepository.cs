using Microsoft.EntityFrameworkCore;
using Nutra.Domain.Entidades;
using Nutra.Domain.Repository;

namespace Nutra.API.Infrastructure.Repository;

public class RegrasDesafiosRepository : IRegrasDesafiosRepository
{
    private readonly ApplicationDbContext _context;

    public RegrasDesafiosRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<RegrasDesafios?> ObterPorIdAsync(int id)
    {
        return await _context.RegrasDesafios
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<List<RegrasDesafios>> ObterPorIdOpcao(int idOpcao, CancellationToken cancellationToken)
    {
        return await _context.RegrasDesafios
                .AsNoTracking()
                .Where(r => r.IdOpcao == idOpcao)
                .ToListAsync(cancellationToken);
    }
}
