using Microsoft.EntityFrameworkCore;
using Nutra.Domain.Entidades;
using Nutra.Domain.Repository;

namespace Nutra.API.Infrastructure.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UsuarioRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task CriarUsuario(Usuarios usuarios, CancellationToken cancellationToken)
    {
        await _dbContext.Usuarios.AddAsync(usuarios, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Usuarios>> Listar(CancellationToken cancellationToken)
    {
        return await _dbContext.Usuarios
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<Usuarios?> ListarId(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.Usuarios
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<bool> DeletarUsuario(int id, CancellationToken cancellationToken)
    {
        var usuario = await _dbContext.Usuarios.FindAsync(new object[] { id }, cancellationToken);
    
        if (usuario == null)
            return false; 

        _dbContext.Usuarios.Remove(usuario);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return true; 
    }

    public async Task AtualizarUsuario(Usuarios usuarios, CancellationToken cancellationToken)
    {
         _dbContext.Usuarios.Update(usuarios);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }


}