using Microsoft.EntityFrameworkCore;
using Nutra.Domain.Entidades;
using Nutra.Domain.Repository;

namespace Nutra.API.Infrastructure.Repository;

public class RegistrosRepository : IRegistrosRepository
{
    private readonly ApplicationDbContext _context;

    public RegistrosRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CriarRegistros(Registros registroses, CancellationToken cancellationToken)
    {
        await _context.AddAsync(registroses, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Registros>> ListarRegistros(CancellationToken cancellationToken)
    {
        return await _context.Registros
            .Include(r => r.Usuarios)   
            .Include(r => r.Tipo)      
            .ToListAsync(cancellationToken);
    }
    public async Task<Registros?> ListarId(int id, CancellationToken cancellationToken)
    {
        return await _context.Registros
            .Include(r => r.Usuarios)
            .Include(r => r.Tipo)
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
    }
    public async Task<bool> DeletarRegistros(int id, CancellationToken cancellationToken)
    {
        var registro = await _context.Registros.FindAsync(new object[] { id }, cancellationToken);
    
        if (registro == null)
            return false; 

        _context.Registros.Remove(registro);
        await _context.SaveChangesAsync(cancellationToken);

        return true; 
    }
    public async Task AtualizarRegistros(Registros registros, int idUsuario, CancellationToken cancellationToken)
    {
        if (registros.IdUsuario != idUsuario)
            throw new Exception("Este registro não pertence ao usuário informado.");

        _context.Registros.Update(registros);
        await _context.SaveChangesAsync(cancellationToken);
    }

}