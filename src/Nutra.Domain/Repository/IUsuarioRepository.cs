using Nutra.Domain.Entidades;
namespace Nutra.Domain.Repository;
public interface IUsuarioRepository
{
    Task CriarUsuario(Usuarios usuarios, CancellationToken cancellationToken);
    Task<List<Usuarios>> Listar(CancellationToken cancellationToken);
    Task<Usuarios> ListarId(int id, CancellationToken cancellationToken);
    Task<bool> DeletarUsuario(int id, CancellationToken cancellationToken);
    Task AtualizarUsuario(Usuarios usuarios, CancellationToken cancellationToken);
}