using Nutra.Domain.Entidades;

namespace Nutra.Domain.Repository;

public interface IUsuariosRepository
{
    Task CriarUsuarios(Usuarios usuarios, CancellationToken cancellationToken);
}