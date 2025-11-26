using Microsoft.EntityFrameworkCore;
using Nutra.Domain.Entidades;
using Nutra.Domain.Enums;
using Nutra.Domain.Repository;
namespace Nutra.API.Infrastructure.Repository;

public class TipoRegistroRepository : ITipoRegistroRepository
{
    private readonly ApplicationDbContext _context;

    public TipoRegistroRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TipoRegistro?> ObterPorCategoriaETipo(CategoriaRegistro categoria, TipoDetalhe tipoEspecifico,
        CancellationToken cancellationToken)
    {
        var query = _context.Set<TipoRegistro>().AsQueryable();

        query = query.Where(t => t.Categoria == categoria);

        query = query.Where(t => t.TipoDetalhe == tipoEspecifico);

        return await query.FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<TipoRegistro>> ObterPorCategoria(CategoriaRegistro categoria,
        CancellationToken cancellationToken)
    {
        return await _context.TipoRegistro
            .Where(tp => tp.Categoria == categoria)
            .ToListAsync(cancellationToken);
    }

    public async Task<TipoRegistro?> ObterPorId(int id, CancellationToken cancellationToken)
    {
        return await _context.TipoRegistro
            .FirstOrDefaultAsync(tr => tr.Id == id, cancellationToken);
    }
}