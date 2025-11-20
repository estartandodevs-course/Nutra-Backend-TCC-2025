using Microsoft.EntityFrameworkCore;
using Nutra.Domain.Entidades;
using Nutra.Domain.Repository;

namespace Nutra.API.Infrastructure.Repository;

public class RespostaRepository : IRespostasRepository
{
    private readonly ApplicationDbContext _context;

    public RespostaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

   public async Task CriarResposta(IEnumerable<Respostas> respostas, CancellationToken cancellationToken)
    {
        await _context.Respostas.AddRangeAsync(respostas, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Domain.Entidades.Respostas>> ListarRespostas(CancellationToken cancellationToken)
    {
        return await _context.Respostas
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<bool> DeletarRespostas(int id, CancellationToken cancellationToken)
    {
        var resposta = await _context.Respostas.FindAsync(new object[] { id }, cancellationToken);
    
        if (resposta == null)
            return false; 

        _context.Respostas.Remove(resposta);
        await _context.SaveChangesAsync(cancellationToken);

        return true; 
    }
    
}