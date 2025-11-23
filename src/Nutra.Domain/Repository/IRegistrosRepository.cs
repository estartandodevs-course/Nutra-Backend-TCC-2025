using Nutra.Domain.Entidades;
namespace Nutra.Domain.Repository;

public interface IRegistrosRepository
{
    Task CriarRegistros(Registros registroses,CancellationToken cancellationToken);
    Task<List<Registros>> ListarRegistros(CancellationToken cancellationToken);
    Task<Registros> ListarId(int id, CancellationToken cancellationToken);

    Task<bool> DeletarRegistros(int idUsuario, CancellationToken cancellationToken);
    
    Task AtualizarRegistros(Registros registros, int idUsuario, CancellationToken cancellationToken);
}