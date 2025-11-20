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

    public async Task<TipoRegistro?> ObterPorCategoria(string categoria, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(categoria))
            return null;

        // tenta converter a string para o enum (ignora maiúsc/minúsc)
        if (!Enum.TryParse<CategoriaRegistro>(categoria.Trim(), true, out var categoriaEnum))
            return null; // categoria inválida -> não existe no enum

        // agora a comparação é enum == enum (translável pelo EF)
        return await _context.TipoRegistro
            .FirstOrDefaultAsync(t => t.Categoria == categoriaEnum, ct);
    }


    /*public async Task<TipoRegistro?> ObterPorId(int id, CancellationToken ct)
    {
        return await _context.TiposRegistro
            .FirstOrDefaultAsync(t => t.Id == id, ct);
    }

    public async Task<List<TipoRegistro>> ListarTodos(CancellationToken ct)
    {
        return await _context.TiposRegistro.ToListAsync(ct);
    }*/
}