using Microsoft.EntityFrameworkCore;
using Nutra.Domain.Entidades;
using Nutra.Domain.Repository;

namespace Nutra.API.Infrastructure.Repository;

public class ProgressosRepository : IProgressosRepository
{
    private readonly ApplicationDbContext _context;

    public ProgressosRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(int idUsuario, int idDesafio, int QuantidadeAtual, CancellationToken cancellationToken)
    {
        Progressos progresso = new(idUsuario, idDesafio)
        {
            QuantidadeAtual = QuantidadeAtual
        };

        await _context.Progressos.AddAsync(progresso, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Progressos?> ObterPorIdAsync(int id)
    {
        return await _context.Progressos
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == id);
    }
}
