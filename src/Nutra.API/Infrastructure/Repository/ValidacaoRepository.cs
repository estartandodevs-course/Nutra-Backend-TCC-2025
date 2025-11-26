using Microsoft.EntityFrameworkCore;
using Nutra.Domain.Entidades;
using Nutra.Domain.Repository;

namespace Nutra.API.Infrastructure.Repository;

public class ValidacaoRepository : IValidacaoRepository
{
    private readonly ApplicationDbContext _context;

    public ValidacaoRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<bool> ExisteQuestionario(int id, CancellationToken cancellationToken)
    {
        return await _context.Questionarios.AnyAsync(q => q.Id == id, cancellationToken);
    }

    public async Task<bool> ExistemPerguntas(int questionarioId, List<int> perguntasIds, CancellationToken cancellationToken)
    {
        var count = await _context.Perguntas
            .Where(p => perguntasIds.Contains(p.Id) && p.IdQuestionario == questionarioId)
            .CountAsync(cancellationToken);
        
        return count == perguntasIds.Count;
    }
    public async Task<bool> ExistemOpcoes(List<int> perguntasIds, List<int> opcoesIds, CancellationToken cancellationToken)
    {
        var count = await _context.Opcoes
            .Where(o => perguntasIds.Contains(o.IdPergunta) && opcoesIds.Contains(o.Id))
            .CountAsync(cancellationToken);
    
        return count == opcoesIds.Count;
    }

    public async Task<bool> ExistemRespostas(int idUsuario, CancellationToken cancellationToken)
    {
        var count = await _context.Respostas
            .Where(r => r.IdUsuario == idUsuario)
            .CountAsync(cancellationToken);

        return count > 0;

    }
}