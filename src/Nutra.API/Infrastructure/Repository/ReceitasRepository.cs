using Microsoft.EntityFrameworkCore;
using Nutra.API.Infrastructure;
using Nutra.Domain.Entidades;
using Nutra.Domain.Repository;

namespace Nutra.API.Infrastructure.Repositorys;

public class ReceitasRepository : IReceitasRepository
{
    private readonly ApplicationDbContext _context;

    public ReceitasRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Receitas> AdicionarAsync(Receitas receita)
    {
        _context.Receitas.Add(receita);
        await _context.SaveChangesAsync();
        return receita;
    }

    public async Task<List<Receitas>> ObterTodasAsync()
    {
        return await _context.Receitas
            .AsNoTracking()
            .OrderBy(r => r.Nome)
            .ToListAsync();
    }

    public async Task<Receitas?> ObterPorIdAsync(int id)
    {
        return await _context.Receitas
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == id);
    }

}
